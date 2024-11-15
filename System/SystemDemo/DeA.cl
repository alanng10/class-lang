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

        this.TextInfra : share TextInfra;

        var StringAdd h;
        h : new StringAdd;
        h.Init();

        this.TextInfra.AddString(h, "k: \n");
        this.TextInfra.AddString(h, k);
        this.TextInfra.AddString(h, "\n");

        var String a;
        
        a : h.Result();

        console.Out.Write(a);

        var Data ka;
        ka : new Data;
        ka.Count : 10 * 1024 * 1024;
        ka.Init();

        console.Out.Write("Demo HHHH\n");

        return true;
    }

    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
}