using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Core.Data.Context
{
    internal sealed class AppDbContext : IDisposable, IAsyncDisposable, IAppDbContext
    {
        private readonly NpgsqlDataSource dataSource;
        private readonly DatabaseSettings databaseSettings;
        private readonly ILogger<AppDbContext> logger;

        public AppDbContext(ILoggerFactory factory, ILogger<AppDbContext> logger, IOptions<DatabaseSettings> databaseSettings)
        {
            this.databaseSettings = databaseSettings.Value;
            this.logger = logger;
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(CreateConnectionString());
            dataSourceBuilder.UseLoggerFactory(factory);
            dataSource = dataSourceBuilder.Build();
        }

        public NpgsqlCommand CreateCommand(string? commandText = null)
            => dataSource.CreateCommand(commandText);

        public async Task<NpgsqlConnection> CreateConnectionAsync(CancellationToken cancellationToken = default!)
            => await dataSource.OpenConnectionAsync(cancellationToken);

        public async Task EnsureCreateDatabaseAsync(CancellationToken cancellationToken = default!)
        {
            var connectionString = CreateConnectionString("postgres");
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            if (!await DatabaseExistsAsync(dataSource, cancellationToken))
            {
                await CreateDatabaseAsync(dataSource, cancellationToken);
                await CreateTablesAsync(cancellationToken);
            }
            else
            {
                logger.LogInformation("Database '{database}' already exists.", databaseSettings.Database);
            }
        }

        public async Task EnsureDeleteDatabaseAsync(CancellationToken cancellationToken = default!)
        {
            var connectionString = CreateConnectionString("postgres");
            await using var dataSource = NpgsqlDataSource.Create(connectionString);
            if (await DatabaseExistsAsync(dataSource, cancellationToken))
            {
                await DeleteDatabaseAsync(dataSource, cancellationToken);
            }
        }

        private async Task DeleteDatabaseAsync(NpgsqlDataSource dataSource, CancellationToken cancellationToken)
        {
            try
            {
                var commandText = $"DROP DATABASE \"{databaseSettings.Database}\"";
                await using var cmd = dataSource.CreateCommand(commandText);
                await cmd.ExecuteNonQueryAsync(cancellationToken);
                logger.LogInformation("Database '{database}' dropped.", databaseSettings.Database);
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred while dropping database: {message} ", ex.Message);
                throw;
            }
        }

        private async Task CreateTablesAsync(CancellationToken cancellationToken)
        {
            try
            {
                string commandText = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Scripts\\CreateTables.sql"));
                await using var cmd = CreateCommand(commandText);
                await cmd.ExecuteNonQueryAsync(cancellationToken);
                logger.LogInformation("Tables created successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred while creating tables: {message} ", ex.Message);
                throw;
            }
        }

        private async Task CreateDatabaseAsync(NpgsqlDataSource dataSource, CancellationToken cancellationToken)
        {
            try
            {
                var commandText = $"CREATE DATABASE \"{databaseSettings.Database}\"";
                await using var cmd = dataSource.CreateCommand(commandText);
                await cmd.ExecuteNonQueryAsync(cancellationToken);
                logger.LogInformation("Database '{database}' created.", databaseSettings.Database);
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred while creating database: {message} ", ex.Message);
                throw;
            }
        }

        private async Task<bool> DatabaseExistsAsync(NpgsqlDataSource dataSource, CancellationToken cancellationToken)
        {
            var commandText = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{databaseSettings.Database}'";
            await using var cmd = dataSource.CreateCommand(commandText);
            var result = await cmd.ExecuteScalarAsync(cancellationToken);
            var dbCount = result as long? ?? 0;
            return dbCount > 0;
        }

        private string CreateConnectionString(string? database = default!)
        {
            return new NpgsqlConnectionStringBuilder
            {
                Host = databaseSettings.Host,
                Port = databaseSettings.Port,
                Username = databaseSettings.Username,
                Password = databaseSettings.Password,
                Database = database ?? databaseSettings.Database,
                ApplicationName = "RFBDadosAbertosCNPJ",
                CommandTimeout = 0,
            }.ToString();
        }

        public void Dispose()
            => dataSource.Dispose();

        public ValueTask DisposeAsync()
            => dataSource.DisposeAsync();
    }
}
