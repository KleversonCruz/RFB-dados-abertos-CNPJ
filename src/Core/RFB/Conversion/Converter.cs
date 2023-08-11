using Core.Data;
using Core.Data.Context;
using Microsoft.Extensions.Logging;

namespace Core.RFB.Conversion
{
    internal interface IConverter
    {
        Task Convert(string filePath, CancellationToken cancellationToken);
    }

    internal class Converter<TEntity> : IConverter where TEntity : class
    {
        private readonly ILogger<Converter<TEntity>> logger;
        private readonly IAppDbContext dbContext;

        public Converter(ILogger<Converter<TEntity>> logger, IAppDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task Convert(string filePath, CancellationToken cancellationToken)
        {
            try
            {
                var fileName = Path.GetFileName(filePath);
                logger.LogInformation("Inserting file '{fileName}' data into the database.", fileName);
                using var command = dbContext.CreateCommand();
                await command.BulkInsert<TEntity>(filePath, cancellationToken);
                logger.LogInformation("Data insertion for '{entityName}' from file '{fileName}' completed.", typeof(TEntity).Name, fileName);
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred: {message} ", ex.Message);
                throw;
            }
        }
    }
}
