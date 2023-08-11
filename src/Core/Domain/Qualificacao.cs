using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    [Table("Qualificacoes")]
    public class Qualificacao
    {
        public string Codigo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
    }
}
