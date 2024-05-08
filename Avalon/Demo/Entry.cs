namespace Demo;

class Entry : EntryEntry
{
    protected override int ExecuteMain()
    {
        Demo demo;
        demo = new Demo();
        demo.Init();
        demo.Execute();
        return 0;
    }

    [STAThread]
    static int Main(string[] arg)
    {
        EntryEntry a;
        a = new Entry();
        a.Init();
        int o;
        o = a.Execute();
        return o;
    }
}