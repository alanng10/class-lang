class ConsoleIntern : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.Intern : 0;
        return true;
    }

    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }

    maide prusate Bool Write(var Int stream, var String a)
    {
        var Bool b;
        b : (stream = 0);
        inf (b)
        {
            this.OutWrite(a);
        }
        inf (~b)
        {
            this.ErrWrite(a);
        }
        return true;
    }

    maide prusate Bool OutWrite(var String a)
    {
        var Int k;
        k : this.InternInfra.StringCreate(a);
        
        this.Extern.Console_OutWrite(this.Intern, k);

        this.InternInfra.StringDelete(k);
        return true;
    }

    maide prusate Bool ErrWrite(var String a)
    {
        var Int k;
        k : this.InternInfra.StringCreate(a);
        
        this.Extern.Console_ErrWrite(this.Intern, k);

        this.InternInfra.StringDelete(k);
        return true;
    }

    maide prusate String Read()
    {
        var Int k;
        k : this.Extern.Console_InnRead(this.Intern);

        var String a;
        a : this.InternInfra.StringCreateIntern(k);

        this.InternInfra.StringDelete(k);
        return a;
    }
}