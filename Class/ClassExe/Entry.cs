namespace ClassExe;

class Entry
{
    [STAThread]
    static int Main(string[] arg)
    {
        ClassEntry entry;
        entry = new ClassEntry();
        entry.ArgSet(arg);
        entry.Init();
        int o;
        o = entry.Execute();
        return o;
    }
}