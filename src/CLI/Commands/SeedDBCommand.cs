using Core.Data.Initialization;
using McMaster.Extensions.CommandLineUtils;

[Command(Name = "seed", Description = "Seed database with initial data.")]
internal class SeedDBCommand
{
    [Option(Description = "Execute the seed process with only necessary information.")]
    public bool Partial { get; set; }

    public async Task<int> OnExecuteAsync(IAppSeeder appSeeder, CancellationToken cancellationToken)
    {
        if (Partial)
            await appSeeder.SeedEmpresaDatabaseAsync(cancellationToken);
        else
            await appSeeder.SeedFullDatabaseAsync(cancellationToken);

        return 0;
    }
}