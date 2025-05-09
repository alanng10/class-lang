class DemoA : Any
{
    maide prusate Bool Execute()
    {
        var Console console;
        console : share Console;
        
        console.Out.Write("DemoA Execute\n");
        return true;
    }

    maide precate Bool ExecuteA()
    {
        share Console.Out.Write("Demo Dot Precate\n");
        return true;
    }

    field precate Int Aa { get { share Console.Out.Write("DemoA Field Get\n"); } set { share Console.Out.Write("DemoA Field Set\n"); } }
    field precate String Ake { get { return data; } set { data : value; } }
}