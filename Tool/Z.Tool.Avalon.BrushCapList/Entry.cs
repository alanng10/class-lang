namespace Z.Tool.Avalon.BrushCapList;

class Entry : EntryEntry
{
    protected override long ExecuteMain()
    {
        Gen gen;
        gen = new Gen();
        gen.Init();
        int o;
        o = gen.Execute();
        return o;
    }

    [STAThread]
    static int Main()
    {
        EntryEntry a;
        a = new Entry();
        a.Init();
        int o;
        o = a.Execute();
        return o;
    }
}