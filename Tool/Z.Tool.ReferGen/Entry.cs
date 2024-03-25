namespace Z.Tool.ReferGen;

class Entry : EntryEntry
{
    public override int Execute()
    {
        Gen gen;
        gen = new Gen();
        gen.Init();
        int o;
        o = gen.Execute();
        return o;
    }

    static int Main()
    {
        Exe exe;
        exe = new Exe();
        exe.Init();
        int o;
        o = exe.Execute();
        return o;
    }
}