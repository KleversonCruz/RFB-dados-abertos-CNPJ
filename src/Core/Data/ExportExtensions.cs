using CsvHelper;
using CsvHelper.Configuration;
using System.Data.Common;
using System.Globalization;
using System.Text;

namespace Core.Data
{
    public static class ExportExtensions
    {
        public static async Task ExportToCsvAsync(this DbDataReader dataReader, string filePath, string? delimiter = ";", CancellationToken cancellationToken = default)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter,
                Encoding = Encoding.Latin1,
            };

            using var writer = new StreamWriter(filePath);
            using var csvWriter = new CsvWriter(writer, csvConfig);

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                csvWriter.WriteField(dataReader.GetName(i));
            }
            await csvWriter.NextRecordAsync();

            while (await dataReader.ReadAsync(cancellationToken))
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    csvWriter.WriteField(dataReader[i]);
                }
                await csvWriter.NextRecordAsync();
            }
        }
    }
}
