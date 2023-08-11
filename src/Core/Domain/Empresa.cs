namespace Core.Domain
{
    public class Empresa
    {
        public string CnpjBasico { get; set; } = default!;
        public string RazaoSocial { get; set; } = default!;
        public string NaturezaJuridica { get; set; } = default!;
        public string QualificacaoResponsavel { get; set; } = default!;
        public string CapitalSocial { get; set; } = default!;
        public string PorteEmpresa { get; set; } = default!;
        public string EnteFederativoResponsavel { get; set; } = default!;
    }
}
