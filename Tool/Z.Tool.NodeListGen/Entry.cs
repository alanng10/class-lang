namespace Z.Tool.NodeListGen;

class Entry : EntryEntry
{
    protected override long ExecuteMain()
    {
        Gen gen;
        gen = new Gen();
        gen.Init();
        long o;
        o = gen.Execute();
        return o;
    }

    [STAThread]
    static int Main(string[] arg)
    {
        EntryEntry a;
        a = new Entry();
        a.Init();
        a.ArgSet(arg);
        int o;
        o = a.Execute();
        return o;
    }
}