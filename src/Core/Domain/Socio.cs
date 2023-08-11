using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    [Table("Socios")]
    public class Socio
    {
        public string CnpjBasico { get; set; } = default!;
        public string IdentificadorSocio { get; set; } = default!;
        public string NomeSocio { get; set; } = default!;
        public string CnpjCpfSocio { get; set; } = default!;
        public string QualificacaoSocio { get; set; } = default!;
        public string DataEntradaSociedade { get; set; } = default!;
        public string Pais { get; set; } = default!;
        public string RepresentanteLegal { get; set; } = default!;
        public string NomeRepresentante { get; set; } = default!;
        public string QualificacaoRepresentante { get; set; } = default!;
        public string FaixaEtaria { get; set; } = default!;
    }
}
