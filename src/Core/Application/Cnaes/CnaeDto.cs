namespace Core.Application.Cnaes
{
    public class CnaeDto
    {
        public string Codigo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public string Display => $"{Codigo} - {Descricao}";
    }
}
