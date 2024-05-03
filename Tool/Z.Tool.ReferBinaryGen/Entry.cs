namespace Z.Tool.ReferBinaryGen;

class Entry : EntryEntry
{
    public override int Execute()
    {
        Main main;
        main = new Main();
        main.Init();

        Gen gen;
        gen = new Gen();
        gen.Init();
        int o;
        o = gen.Execute();
        
        main.Final();
        return o;
    }

    [STAThread]
    static int Main()
    {
        Entry entry;
        entry = new Entry();
        entry.Init();
        int o;
        o = entry.Execute();
        return o;
    }
}