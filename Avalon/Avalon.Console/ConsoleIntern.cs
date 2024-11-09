namespace Avalon.Console;

class ConsoleIntern : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        return true;
    }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Write(long stream, String a)
    {
        bool b;
        b = (stream == 0);
        if (b)
        {
            this.OutWrite(a);
        }
        if (!b)
        {
            this.ErrWrite(a);
        }
        return true;
    }


    public virtual bool OutWrite(String a)
    {
        ulong uo;
        uo = this.InternInfra.StringCreate(a);
        
        Extern.Console_OutWrite(this.Intern, uo);

        this.InternInfra.StringDelete(uo);
        return true;
    }

    public virtual bool ErrWrite(String a)
    {
        ulong uo;
        uo = this.InternInfra.StringCreate(a);
        
        Extern.Console_ErrWrite(this.Intern, uo);

        this.InternInfra.StringDelete(uo);
        return true;
    }

    public virtual String Read()
    {
        ulong u;
        u = Extern.Console_InnRead(this.Intern);

        String a;
        a = this.InternInfra.StringCreateIntern(u);

        this.InternInfra.StringDelete(u);
        return a;
    }
}