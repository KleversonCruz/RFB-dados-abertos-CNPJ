
using Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

try
{
    await Host.CreateDefaultBuilder()
    .ConfigureLogging((context, builder) =>
        builder.AddConsole())
    .ConfigureServices((context, services) =>
        services.AddCore(context.Configuration))
    .RunCommandLineApplicationAsync<RootCommand>(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}