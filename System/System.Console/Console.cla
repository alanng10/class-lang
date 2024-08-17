class Console : Any
{
    maide prusate Bool Init()
    {
        base.Init();

        this.Intern : new ConsoleIntern;
        this.Intern.Init();

        var ConsoleOut oa;
        oa : new ConsoleOut;
        oa.Init();
        oa.Intern : this.Intern;
        oa.Stream : 0;
        this.Out : oa;

        var ConsoleOut ob;
        ob : new ConsoleOut;
        ob.Init();
        ob.Intern : this.Intern;
        ob.Stream : 1;
        this.Err : ob;

        var ConsoleInn oc;
        oc : new ConsoleInn;
        oc.Init();
        oc.Intern : this.Intern;
        this.Inn : oc;

        return true;
    }

    field private ConsoleIntern Intern { get { return data; } set { data : value; } }

    field prusate Out Out { get { return data; } set { data : value; } }

    field prusate Out Err { get { return data; } set { data : value; } }

    field prusate Inn Inn { get { return data; } set { data : value; } }
}