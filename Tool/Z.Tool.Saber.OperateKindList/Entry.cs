namespace Z.Tool.Saber.OperateKindList;

class Entry : EntryEntry
{
    protected override long ExecuteMain()
    {
        Gen gen;
        gen = new Gen();
        gen.Init();
        long k;
        k = gen.Execute();
        return k;
    }

    [STAThread]
    static int Main(string[] arg)
    {
        EntryEntry a;
        a = new Entry();
        a.Init();
        a.ArgSet(arg);
        int k;
        k = a.Execute();
        return k;
    }
}