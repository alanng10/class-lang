namespace ClassExe;

class Entry
{
    [STAThread]
    static int Main(string[] arg)
    {
        ClassEntry entry;
        entry = new ClassEntry();
        entry.Init();
        entry.ArgSet(arg);
        int o;
        o = entry.Execute();
        return o;
    }
}