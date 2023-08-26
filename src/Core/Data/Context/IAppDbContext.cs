using Npgsql;

namespace Core.Data.Context
{
    public interface IAppDbContext
    {
        NpgsqlCommand CreateCommand(string? commandText = null);
        Task<NpgsqlConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
        Task EnsureCreateDatabaseAsync(CancellationToken cancellationToken = default);
        Task EnsureDeleteDatabaseAsync(CancellationToken cancellationToken = default);
        Task CreateIndexes(CancellationToken cancellationToken = default);
        Task CreateViews(CancellationToken cancellationToken = default);
        void Dispose();
        ValueTask DisposeAsync();
    }
}