using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    [Table("Paises")]
    public class Pais
    {
        public string Codigo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
    }
}
