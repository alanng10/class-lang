namespace Class.Console;

public class Entry : EntryEntry
{
    public override int Execute()
    {
        Main main;
        main = new Main();
        main.Init();
        Console console;
        console = new Console();
        console.Init();
        console.Arg = this.Arg;
        int a;
        a = console.Execute();
        main.Final();
        return a;
    }
}