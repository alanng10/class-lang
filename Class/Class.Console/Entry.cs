namespace Class.Console;

public class Entry : EntryEntry
{
    protected override int ExecuteMain()
    {
        Console console;
        console = new Console();
        bool b;
        b = console.Init();
        if (b)
        {
            console.ArgSet(this.Arg);
            console.Execute();
        }
        int a;
        a = console.Status;
        return a;
    }
}