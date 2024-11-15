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

        var TextInfra textInfra;
        textInfra : share TextInfra;

        var StringAdd h;
        h : new StringAdd;
        h.Init();

        textInfra.AddString(h, "k: \n");
        textInfra.AddString(h, k);
        textInfra.AddString(h, "\n");

        var String a;
        
        a : h.Result();

        console.Out.Write(a);
        return true;
    }
}