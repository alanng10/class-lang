namespace Z.Tool.ReferBinaryGen;

class Entry : EntryEntry
{
    public override int Execute()
    {
        Gen gen;
        gen = new Gen();
        gen.Init();
        int o;
        o = gen.Execute();
        gen.Final();
        return o;
    }

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