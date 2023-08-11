using Core.Domain;

namespace Core.RFB.Conversion
{
    internal class ConverterFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Type> _fileTypeMappings;

        public ConverterFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _fileTypeMappings = new Dictionary<string, Type>
            {
                { "EMPRECSV", typeof(Empresa) },
                { "CNAECSV", typeof(Cnae) },
                { "SIMPLES", typeof(Simples) },
                { "MOTI", typeof(Motivo) },
                { "MUNIC", typeof(Municipio) },
                { "NATJU", typeof(Natureza) },
                { "PAIS", typeof(Pais) },
                { "QUALS", typeof(Qualificacao) },
                { "ESTABELE", typeof(Estabelecimento) },
                { "SOCIOCSV", typeof(Socio) }
            };
        }

        public IConverter Create(string fileName)
        {
            var mapping = _fileTypeMappings.FirstOrDefault(x => fileName.Contains(x.Key));
            if (mapping.Key != null)
            {
                var converterType = typeof(Converter<>).MakeGenericType(mapping.Value);
                return (IConverter)_serviceProvider.GetService(converterType)!;
            }
            throw new NotSupportedException($"Unsupported CSV file type: {fileName}");
        }
    }
}
