class DemoB : DemoA
{
    maide prusate Bool Execute()
    {
        base.Execute();

        var Console console;
        console : share Console;
        
        console.Out.Write("DemoB Execute\n");
        return true;
    }

    field precate Int Aa { get { base.Aa; share Console.Out.Write("DemoB Field Get\n"); } set { base.Aa : null; share Console.Out.Write("DemoB Field Set\n"); } }
    field precate String Ake { get { return base.Ake; } set { base.Ake : value; } }
}