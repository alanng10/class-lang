class Console : Any
{
    maide prusate Bool Init()
    {
        base.Init();

        this.Intern : new ConsoleIntern;
        this.Intern.Init();

        var ConsoleOut ka;
        ka : new ConsoleOut;
        ka.Init();
        ka.Intern : this.Intern;
        ka.Stream : 0;
        this.Out : ka;

        var ConsoleOut kb;
        kb : new ConsoleOut;
        kb.Init();
        kb.Intern : this.Intern;
        kb.Stream : 1;
        this.Err : kb;

        var ConsoleInn kc;
        kc : new ConsoleInn;
        kc.Init();
        kc.Intern : this.Intern;
        this.Inn : kc;

        return true;
    }

    field private ConsoleIntern Intern { get { return data; } set { data : value; } }

    field prusate Out Out { get { return data; } set { data : value; } }

    field prusate Out Err { get { return data; } set { data : value; } }

    field prusate Inn Inn { get { return data; } set { data : value; } }
}