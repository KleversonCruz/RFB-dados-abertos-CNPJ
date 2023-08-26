using Core.Data.Context;
using Core.Domain;
using Dapper;
using MediatR;

namespace Core.Application.Cnaes
{
    public class GetCnaesRequest : IRequest<IEnumerable<CnaeDto>> { }

    public class GetCnaesHandler : IRequestHandler<GetCnaesRequest, IEnumerable<CnaeDto>>
    {
        private readonly IAppDbContext dbContext;

        public GetCnaesHandler(IAppDbContext dbContext) =>
            this.dbContext = dbContext;

        public async Task<IEnumerable<CnaeDto>> Handle(GetCnaesRequest request, CancellationToken cancellationToken)
        {
            using var connection = await dbContext.CreateConnectionAsync(cancellationToken);
            var sql = "SELECT * FROM \"Cnaes\"";

            return await connection.QueryAsync<CnaeDto>(sql);
        }
    }
}
