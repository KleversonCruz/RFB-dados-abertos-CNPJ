using System.IO.Compression;
using System.Text;

namespace Core.RFB
{
    internal static class ZipExtensions
    {
        public static async Task ExtractToDirectoryAsync(this ZipArchive source, string destinationDirectoryName, CancellationToken cancellationToken)
        {
            foreach (var entry in source.Entries)
            {
                string entryDestinationPath = Path.Combine(destinationDirectoryName, entry.FullName);

                if (!File.Exists(entryDestinationPath))
                {
                    using Stream inputStream = entry.Open();
                    using Stream outputStream = File.Create(entryDestinationPath);
                    var encoding = Encoding.GetEncoding("LATIN1");

                    using var reader = new StreamReader(inputStream, encoding);
                    using var writer = new StreamWriter(outputStream, encoding);
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync(cancellationToken);
                        line = CleanCSV(line);
                        await writer.WriteLineAsync(line);
                    }
                }
            }
        }

        private static string CleanCSV(string? line)
            => new(line?.Where(c => c != '\0').ToArray());
    }
}
