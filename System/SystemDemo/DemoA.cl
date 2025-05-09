class DemoA : Add
{
    field precate Int Aa { get { share Console.Out.Write("DemoA Field Get\n"); } set { share Console.Out.Write("DemoA Field Set\n"); } }
    field precate String Ake { get { return data; } set { data : value; } }

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

    maide prusate String StatusString(var Bool b)
    {
        var String k;
        k : "Success";
        inf (~b)
        {
            k : "Error";
        }
        return k;
    }
}