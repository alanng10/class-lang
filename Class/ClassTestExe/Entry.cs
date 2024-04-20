namespace Class.Test.Exe;



class Entry
{
    [STAThread]
    static int Main()
    {
        TestEntry entry;

        entry = new TestEntry();

        entry.Init();



        int o;

        o = entry.Execute();


        return o;
    }
}