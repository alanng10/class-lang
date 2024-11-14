class DeA : Dem
{
    maide prusate Bool Execute()
    {
        base.Execute();

        var Console console;
        console : share Console;
        
        console.Out.Write("Demo ABCD AAAA BBBB\n");
        return true;
    }
}