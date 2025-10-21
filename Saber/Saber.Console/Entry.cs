namespace Saber.Console;

public class Entry : EntryEntry
{
    protected override long ExecuteMain()
    {
        Console console;
        console = new Console();
        console.Init();

        bool b;
        b = console.Load();

        if (!b)
        {
            return 600;
        }

        if (b)
        {
            bool ba;
            ba = console.ArgSet(this.Arg);
            if (ba)
            {
                console.Execute();
            }
        }

        long a;
        a = console.Status;
        return a;
    }
}