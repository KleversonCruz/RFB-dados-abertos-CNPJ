using Core.Data.Context;
using Dapper;
using MediatR;

namespace Core.Application.Estabelecimentos
{
    public class GetEstabelecimentoRequest : IRequest<EstabelecimentoInfoDto>
    {
        public string Cnpj { get; set; } = default!;
    }

    public class GetEstabelecimentoHandler : IRequestHandler<GetEstabelecimentoRequest, EstabelecimentoInfoDto>
    {
        private readonly IAppDbContext dbContext;

        public GetEstabelecimentoHandler(IAppDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<EstabelecimentoInfoDto> Handle(GetEstabelecimentoRequest request, CancellationToken cancellationToken)
        {
            using var connection = await dbContext.CreateConnectionAsync(cancellationToken);

            var sql = $"SELECT * FROM \"EstabelecimentoInfoView\" WHERE \"CnpjBasico\" = @CnpjBasico";

            var records = await connection.QueryAsync<EstabelecimentoInfoDto>(
                new CommandDefinition(sql, new { CnpjBasico = request.Cnpj[..8] }, cancellationToken: cancellationToken));

            return records.Where(e => e.Cnpj == request.Cnpj).FirstOrDefault()
                ?? throw new Exception("Nenhum estabelecimento foi encontrado.");
        }
    }
}
