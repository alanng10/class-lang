namespace Z.Tool.Class.ErrorKindList;

class Entry : EntryEntry
{
    public override int Execute()
    {
        Main main;
        main = new Main();
        main.Init();

        Gen gen;
        gen = new Gen();
        gen.Init();
        int o;
        o = gen.Execute();

        main.Final();
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