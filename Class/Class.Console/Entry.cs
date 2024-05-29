namespace Class.Console;

public class Entry : EntryEntry
{
    protected override int ExecuteMain()
    {
        Console console;
        console = new Console();
        console.Init();
        bool b;
        b = console.Load();
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