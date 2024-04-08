namespace ClassExe;

class Entry
{
    [STAThread]
    static int Main(string[] arg)
    {
        EntryEntry entry;
        entry = new ClassEntry();
        entry.ArgSet(arg);
        entry.Init();
        int o;
        o = entry.Execute();
        return o;
    }
}