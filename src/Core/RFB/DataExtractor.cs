using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System.IO.Compression;

namespace Core.RFB
{
    internal interface IDataExtractor
    {
        Task<List<string>> GetPublicDataAsync(CancellationToken cancellationToken = default);
        Task<List<string>> GetPublicDataAsync(List<string>? desiredFiles = null, CancellationToken cancellationToken = default);
    }

    internal class DataExtractor : IDataExtractor
    {
        private readonly ILogger<DataExtractor> logger;
        private readonly string urlReceita;

        public DataExtractor(ILogger<DataExtractor> logger)
        {
            this.logger = logger;
            urlReceita = "https://dadosabertos.rfb.gov.br/CNPJ/";
        }

        public async Task<List<string>> GetPublicDataAsync(CancellationToken cancellationToken = default!)
        {
            return await GetPublicDataAsync(null, cancellationToken);
        }

        public async Task<List<string>> GetPublicDataAsync(List<string>? desiredFileNames = null, CancellationToken cancellationToken = default!)
        {
            var allFilesToDownload = await GetFileNamesAsync();

            var filesToDownload = desiredFileNames != null
                ? allFilesToDownload.Where(file => desiredFileNames.Any(desired => file.Contains(desired))).ToList()
                : allFilesToDownload;

            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var zipDestination = Path.Combine(basePath, "ZIP");
            var zipFileNames = await DownloadFilesAsync(filesToDownload, zipDestination, cancellationToken);

            var csvDestination = Path.Combine(basePath, "CSV");
            var extractedFileNames = await ExtractFilesAsync(zipFileNames, csvDestination, cancellationToken);

            return extractedFileNames.OrderBy(file => Path.GetExtension(file)).ToList();
        }

        private async Task<List<string>> GetFileNamesAsync()
        {
            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(urlReceita);

            return document.DocumentNode.Descendants("a")
                .Select(a => a.GetAttributeValue("href", null))
                .Where(href => href != null && href.EndsWith(".zip"))
                .ToList();
        }

        private async Task<List<string>> DownloadFilesAsync(IEnumerable<string> fileNames, string destinationPath, CancellationToken cancellationToken)
        {
            logger.LogInformation("Downloading {fileCount} file(s) from the server.", fileNames.Count());
            try
            {
                Directory.CreateDirectory(destinationPath);
                var zipFileNames = new List<string>();
                foreach (var fileName in fileNames)
                {
                    logger.LogInformation("Downloading '{fileName}' to {destinationPath}", fileName, destinationPath);
                    var url = $"{urlReceita}/{fileName}";
                    var fileFullName = Path.Combine(destinationPath, fileName);
                    await FileDownloader.DownloadFileAsync(url, fileFullName, cancellationToken);
                    zipFileNames.Add(fileFullName);
                    logger.LogInformation("Download of '{fileName}' completed successfully.", fileName);
                }
                logger.LogInformation("File download process completed.");
                return zipFileNames;
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred: {message} ", ex.Message);
                throw;
            }
        }

        private async Task<List<string>> ExtractFilesAsync(IEnumerable<string> fileNames, string destinationPath, CancellationToken cancellationToken)
        {
            logger.LogInformation("Extracting {fileCount} file(s).", fileNames.Count());
            try
            {
                Directory.CreateDirectory(destinationPath);
                var extractedFileNames = new List<string>();
                foreach (var fileName in fileNames)
                {
                    logger.LogInformation("Extracting {fileName} to {destinationPath}", fileName, destinationPath);
                    var filePath = Path.Combine(destinationPath, fileName);
                    using ZipArchive archive = ZipFile.OpenRead(filePath);
                    await archive.ExtractToDirectoryAsync(destinationPath, cancellationToken);

                    extractedFileNames.AddRange(archive.Entries.Select(entry => Path.Combine(destinationPath, entry.FullName)));
                    logger.LogInformation("Extraction of '{fileName}' completed successfully.", fileName);
                }
                logger.LogInformation("File extraction process completed.");
                return extractedFileNames;
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred: {message} ", ex.Message);
                throw;
            }
        }
    }
}
