class DeA : Dem
{
    maide prusate Bool Execute()
    {
        base.Execute();

        var Console console;
        console : share Console;
        
        console.Out.Write("Demo ABCD AAAA BBBB\n");

        var String k;
        k : console.Inn.Read();

        console.Out.Write("k: \n");
        console.Out.Write(k);
        console.Out.Write("\n");
        return true;
    }
}