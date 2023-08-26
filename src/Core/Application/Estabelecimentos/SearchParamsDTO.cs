using Dapper;
namespace Core.Application.Estabelecimentos
{
    public class SearchParamsDTO
    {
        public string? CnaeFiscalPrincipal { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }
        public string? SituacaoCadastral { get; set; }

        internal SqlBuilder sqlBuilder = new();
        internal SqlBuilder.Template BuildQuery(string sql, dynamic parameters = default!)
        {
            GetParameters();
            return sqlBuilder.AddTemplate(sql, parameters);
        }

        private SqlBuilder GetParameters()
        {
            if (!string.IsNullOrEmpty(CnaeFiscalPrincipal))
                sqlBuilder.Where($"\"CnaeFiscalPrincipal\" = @{nameof(CnaeFiscalPrincipal)}", new { CnaeFiscalPrincipal });
            if (!string.IsNullOrEmpty(Uf))
                sqlBuilder.Where($"\"Uf\" = @{nameof(Uf)}", new { Uf });
            if (!string.IsNullOrEmpty(Cep))
                sqlBuilder.Where($"\"Cep\" LIKE @{nameof(Cep)}", new { Cep = $"{Cep}%" });
            if (!string.IsNullOrEmpty(SituacaoCadastral))
                sqlBuilder.Where($"\"SituacaoCadastral\" = @{nameof(SituacaoCadastral)}", new { SituacaoCadastral });
            return sqlBuilder;
        }
    }
}
