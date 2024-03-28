namespace Class.Console;

public class Entry : EntryEntry
{
    public override int Execute()
    {
        Console console;
        console = new Console();
        console.Init();
        console.Arg = this.Arg;
        return console.Execute();
    }
}