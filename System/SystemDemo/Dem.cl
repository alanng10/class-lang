class Dem : Demo
{
    maide prusate Bool Execute()
    {
        base.Execute();

        var Console console;
        console : share Console;
        
        console.Out.Write("Demo ABCD 5555 6666\n");
        return true;
    }
}