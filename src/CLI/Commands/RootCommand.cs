using McMaster.Extensions.CommandLineUtils;

[Subcommand(typeof(InitializeDBCommand))]
[Subcommand(typeof(SeedDBCommand))]
internal class RootCommand
{
    public int OnExecute(IConsole console, CommandLineApplication app)
    {
        console.WriteLine("You must specify a command.");
        app.ShowHelp();
        return 1;
    }
}