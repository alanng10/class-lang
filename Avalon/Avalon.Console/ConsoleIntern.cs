namespace Avalon.Console;

class ConsoleIntern : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;
        return true;
    }

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
        ulong k;
        k = this.InternInfra.StringCreate(a);

        Extern.Console_OutWrite(this.Intern, k);

        this.InternInfra.StringDelete(k);
        return true;
    }

    public virtual bool ErrWrite(String a)
    {
        ulong k;
        k = this.InternInfra.StringCreate(a);

        Extern.Console_ErrWrite(this.Intern, k);

        this.InternInfra.StringDelete(k);
        return true;
    }

    public virtual String Read()
    {
        ulong k;
        k = Extern.Console_InnRead(this.Intern);

        String a;
        a = this.InternInfra.StringCreateIntern(k);

        this.InternInfra.StringDelete(k);
        return a;
    }
}