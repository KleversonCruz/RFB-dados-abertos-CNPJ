using Core.Data.Context;
using Dapper;
using MediatR;

namespace Core.Application.Estabelecimentos
{
    public class SearchEstabelecimentosRequest : SearchParamsDTO, IRequest<IReadOnlyList<EstabelecimentoInfoDto>>
    {
        public int PageSize { get; set; } = 1000;
    }

    public class SearchEstabelecimentoHandler : IRequestHandler<SearchEstabelecimentosRequest, IReadOnlyList<EstabelecimentoInfoDto>>
    {
        private readonly IAppDbContext dbContext;

        public SearchEstabelecimentoHandler(IAppDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<IReadOnlyList<EstabelecimentoInfoDto>> Handle(SearchEstabelecimentosRequest request, CancellationToken cancellationToken)
        {
            using var connection = await dbContext.CreateConnectionAsync(cancellationToken);
            var query =
                request.BuildQuery($"SELECT * FROM \"EstabelecimentoInfoView\" /**where**/ LIMIT @pageSize", new { request.PageSize });

            var records = await connection.QueryAsync<EstabelecimentoInfoDto>(
                new CommandDefinition(query.RawSql, query.Parameters, cancellationToken: cancellationToken));
            return records.AsList();
        }
    }
}
