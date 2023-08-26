using Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            var host = Host.CreateDefaultBuilder()
             .ConfigureAppConfiguration((context, builder) =>
             {
                 builder.AddJsonFile("appsettings.json", optional: true);
             })
             .ConfigureServices((context, services) =>
             {
                 ConfigureServices(context.Configuration, services);
             }).Build();
            var services = host.Services;

            ApplicationConfiguration.Initialize();

            var formMain = services.GetRequiredService<FormMain>();
            Application.Run(formMain);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<FormMain>();
            services.AddCore(configuration);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is OperationCanceledException || e.Exception.Message.Contains("canceling statement due to user request"))
            {
                MessageBox.Show($"Operação cancelada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show($":\n{e.Exception.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}