namespace Class.Console;

public class Entry : EntryEntry
{
    protected override int ExecuteMain()
    {
        Console console;
        console = new Console();
        console.Init();
        console.ArgSet(this.Arg);
        int a;
        a = console.Execute();
        console.Final();
        return a;
    }
}