namespace Core.RFB
{
    internal static class FileDownloader
    {
        public static async Task DownloadFileAsync(string url, string filePath, CancellationToken cancellationToken)
        {
            if (await IsFileUpToDateOnServer(filePath, url))
                return;

            using var httpClient = new HttpClient();
            httpClient.Timeout = Timeout.InfiniteTimeSpan;
            var response = await httpClient.GetByteArrayAsync(url, cancellationToken);
            await File.WriteAllBytesAsync(filePath, response, cancellationToken);
        }


        private static async Task<bool> IsFileUpToDateOnServer(string fileName, string url)
        {
            if (!File.Exists(fileName))
                return false;

            var request = new HttpRequestMessage(HttpMethod.Head, url);
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var newFileSize = response.Content.Headers.ContentLength;
                var oldFileSize = new FileInfo(fileName).Length;

                return newFileSize == oldFileSize;
            }
            catch (HttpRequestException)
            {
                return true;
            }
        }
    }
}
