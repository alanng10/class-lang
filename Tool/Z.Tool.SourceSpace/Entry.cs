namespace Z.Tool.SourceSpace;

class Entry : EntryEntry
{
    protected override long ExecuteMain()
    {
        SourceSpace k;
        k = new SourceSpace();
        k.Init();
        long a;
        a = k.Execute();
        return a;
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