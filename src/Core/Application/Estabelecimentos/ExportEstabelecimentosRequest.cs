using Core.Data;
using Core.Data.Context;
using Dapper;
using MediatR;

namespace Core.Application.Estabelecimentos
{
    public class ExportEstabelecimentosRequest : SearchParamsDTO, IRequest
    {
        public string FilePath { get; set; } = default!;
    }

    public class ExportEstabelecimentosHandler : IRequestHandler<ExportEstabelecimentosRequest>
    {
        private readonly IAppDbContext dbContext;

        public ExportEstabelecimentosHandler(IAppDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(ExportEstabelecimentosRequest request, CancellationToken cancellationToken)
        {
            using var connection = await dbContext.CreateConnectionAsync(cancellationToken);

            var query =
                request.BuildQuery($"SELECT * FROM \"EstabelecimentoInfoView\" /**where**/");

            var reader = await connection.ExecuteReaderAsync(
                new CommandDefinition(query.RawSql, query.Parameters, cancellationToken: cancellationToken));
            await reader.ExportToCsvAsync(request.FilePath, cancellationToken: cancellationToken);
        }
    }
}
