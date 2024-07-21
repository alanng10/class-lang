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
            bool ba;
            ba = console.ArgSet(this.Arg);
            if (ba)
            {
                console.Execute();
            }
        }

        int a;
        a = console.Status;
        return a;
    }
}