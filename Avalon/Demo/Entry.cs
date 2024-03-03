namespace Demo;

class Entry : EntryEntry
{
    public override int Execute()
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
        Entry entry;
        entry = new Entry();
        entry.Init();
        int o;
        o = entry.Execute();
        return o;
    }
}