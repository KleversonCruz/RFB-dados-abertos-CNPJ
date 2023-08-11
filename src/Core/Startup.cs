using Core.Data;
using Core.Data.Context;
using Core.Data.Initialization;
using Core.RFB;
using Core.RFB.Conversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core
{
    public static class Startup
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration config)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var settings = config.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>() ??
                throw new InvalidOperationException("Não foi possível carregar as configurações da aplicação.");

            return services
                .Configure<DatabaseSettings>(config.GetSection(nameof(DatabaseSettings)))
                .AddTransient<IAppDbContext, AppDbContext>()
                .AddTransient<ConverterFactory>()
                .AddTransient(typeof(Converter<>))
                .AddTransient<IAppInitializer, AppInitializer>()
                .AddTransient<IAppSeeder, AppSeeder>()
                .AddTransient<IDataExtractor, DataExtractor>();
        }
    }
}
