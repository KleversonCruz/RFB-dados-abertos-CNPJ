namespace Core.Domain
{
    public class Estabelecimento
    {
        public string CnpjBasico { get; set; } = default!;
        public string CnpjOrdem { get; set; } = default!;
        public string CnpjDv { get; set; } = default!;
        public string IdentificadorMatrizFilial { get; set; } = default!;
        public string NomeFantasia { get; set; } = default!;
        public string SituacaoCadastral { get; set; } = default!;
        public string DataSituacaoCadastral { get; set; } = default!;
        public string MotivoSituacaoCadastral { get; set; } = default!;
        public string NomeCidadeExterior { get; set; } = default!;
        public string Pais { get; set; } = default!;
        public string DataInicioAtividade { get; set; } = default!;
        public string CnaeFiscalPrincipal { get; set; } = default!;
        public string CnaeSecundario { get; set; } = default!;
        public string TipoLogradouro { get; set; } = default!;
        public string Logradouro { get; set; } = default!;
        public string Numero { get; set; } = default!;
        public string Complemento { get; set; } = default!;
        public string Bairro { get; set; } = default!;
        public string Cep { get; set; } = default!;
        public string Uf { get; set; } = default!;
        public string Municipio { get; set; } = default!;
        public string Ddd1 { get; set; } = default!;
        public string Telefone1 { get; set; } = default!;
        public string Ddd2 { get; set; } = default!;
        public string Telefone2 { get; set; } = default!;
        public string DddFax { get; set; } = default!;
        public string Fax { get; set; } = default!;
        public string CorreioEletronico { get; set; } = default!;
        public string SituacaoEspecial { get; set; } = default!;
        public string DataSituacaoEspecial { get; set; } = default!;
    }
}
