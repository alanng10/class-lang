class DemoB : DemoA
{
    maide prusate Bool Execute()
    {
        base.Execute();

        var Console console;
        console : share Console;
        
        console.Out.Write("Demo ABCD 5555 6666\n");
        return true;
    }

    field precate Int Aa { get { base.Aa; share Console.Out.Write("Dem Field Get\n"); } set { base.Aa : null; share Console.Out.Write("Dem Field Set\n"); } }
    field precate String Ake { get { return base.Ake; } set { base.Ake : value; } }
}