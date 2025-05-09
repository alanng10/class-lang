class DemoA : Any
{
    maide prusate Bool Execute()
    {
        var Console console;
        console : share Console;
        
        console.Out.Write("Demo ABCD 11112222\n");
        return true;
    }

    maide precate Bool ExecuteA()
    {
        share Console.Out.Write("Demo Dot Precate\n");
        return true;
    }

    field precate Int Aa { get { share Console.Out.Write("Demo Field Get\n"); } set { share Console.Out.Write("Demo Field Set\n"); } }
    field precate String Ake { get { return data; } set { data : value; } }
}