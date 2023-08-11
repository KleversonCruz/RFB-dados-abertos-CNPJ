using Core.Data.Initialization;
using McMaster.Extensions.CommandLineUtils;

[Command(Name = "init", Description = "Execute database initialization.")]
internal class InitializeDBCommand
{
    [Option(Description = "Force the initialization process; this may result in potential data loss.")]
    public bool Force { get; set; }

    public async Task<int> OnExecuteAsync(IAppInitializer appInitializer, CancellationToken cancellationToken)
    {
        await appInitializer.InitializeDatabaseAsync(Force, cancellationToken);
        return 0;
    }
}