using Core.RFB;
using Core.RFB.Conversion;
using Microsoft.Extensions.Logging;

namespace Core.Data.Initialization
{
    public interface IAppSeeder
    {
        Task SeedEmpresaDatabaseAsync(CancellationToken cancellationToken = default);
        Task SeedFullDatabaseAsync(CancellationToken cancellationToken);
    }

    internal class AppSeeder : IAppSeeder
    {
        private readonly ILogger<AppSeeder> logger;
        private readonly ConverterFactory converterFactory;
        private readonly IDataExtractor dataExtractor;

        public AppSeeder(ILogger<AppSeeder> logger, ConverterFactory converterFactory, IDataExtractor dataExtractor)
        {
            this.logger = logger;
            this.converterFactory = converterFactory;
            this.dataExtractor = dataExtractor;
        }

        public async Task SeedFullDatabaseAsync(CancellationToken cancellationToken = default!)
        {
            var extractedFiles = await dataExtractor.GetPublicDataAsync(cancellationToken);
            await SeedFilesToDatabaseAsync(extractedFiles, cancellationToken);
        }

        public async Task SeedEmpresaDatabaseAsync(CancellationToken cancellationToken = default!)
        {
            var desiredFileNames = new List<string>() { "Cnaes", "Empresas", "Estabelecimentos", "Municipios" };
            var extractedFileNames = await dataExtractor.GetPublicDataAsync(desiredFileNames, cancellationToken);
            await SeedFilesToDatabaseAsync(extractedFileNames, cancellationToken);
        }

        private async Task SeedFilesToDatabaseAsync(List<string> files, CancellationToken cancellationToken = default!)
        {
            logger.LogInformation("Starting database seeding.");
            foreach (var file in files)
            {
                var converter = converterFactory.Create(file);
                await converter.Convert(file, cancellationToken);
            }
            logger.LogInformation("Database seeding completed successfully.");
        }
    }
}
