namespace Saber.Docue;

public class Entry : EntryEntry
{
    protected override long ExecuteMain()
    {
        Gen gen;
        gen = new Gen();
        gen.Init();
        
        bool b;
        b = gen.Load();

        if (!b)
        {
            return 600;
        }

        if (b)
        {
            bool ba;
            ba = gen.ArgSet(this.Arg);
            if (ba)
            {
                gen.Execute();
            }
        }

        long a;
        a = gen.Status;
        return a;
    }
}