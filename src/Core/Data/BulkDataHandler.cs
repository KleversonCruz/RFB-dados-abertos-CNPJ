using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Core.Data
{
    internal static class BulkDataHandler
    {
        internal static async Task BulkInsert<TEntity>(this NpgsqlCommand command, string filePath, CancellationToken cancellationToken = default)
        {
            command.CommandText = GetCopyCommand<TEntity>(filePath);
            await command.ExecuteNonQueryAsync(cancellationToken);
        }

        private static string GetCopyCommand<TEntity>(string csvFilePath)
        {
            string tableName = GetTableName<TEntity>();
            var properties = typeof(TEntity).GetProperties().Select(property => $"\"{property.Name}\"");
            var commaSeparatedColumns = string.Join(", ", properties);
            return $"COPY {tableName}({commaSeparatedColumns}) FROM '{csvFilePath}' DELIMITER ';' CSV ENCODING 'LATIN1' QUOTE '\"';";
        }

        private static string GetTableName<TEntity>()
        {
            var tableName = typeof(TEntity).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(TEntity).Name + "s";
            return $"\"{tableName}\"";
        }
    }
}
