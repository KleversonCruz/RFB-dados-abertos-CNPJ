using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    [Table("Simples")]
    public class Simples
    {
        public string CnpjBasico { get; set; } = default!;
        public string OpcaoSimples { get; set; } = default!;
        public string DataOpcaoSimples { get; set; } = default!;
        public string DataExclusaoSimples { get; set; } = default!;
        public string OpcaoMei { get; set; } = default!;
        public string DataOpcaoMei { get; set; } = default!;
        public string DataExclusaoMei { get; set; } = default!;
    }
}
