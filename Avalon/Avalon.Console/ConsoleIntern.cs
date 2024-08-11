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

    public virtual bool Write(int stream, string a)
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


    public virtual bool OutWrite(string a)
    {
        ulong uo;
        uo = this.InternInfra.StringCreate(a);
        
        Extern.Console_OutWrite(this.Intern, uo);

        this.InternInfra.StringDelete(uo);
        return true;
    }

    public virtual bool ErrWrite(string a)
    {
        ulong uo;
        uo = this.InternInfra.StringCreate(a);
        
        Extern.Console_ErrWrite(this.Intern, uo);

        this.InternInfra.StringDelete(uo);
        return true;
    }

    public virtual string Read()
    {
        ulong u;
        u = Extern.Console_InnRead(this.Intern);

        ulong data;
        ulong count;
        data = Extern.String_DataGet(u);
        count = Extern.String_CountGet(u);
        
        int k;
        k = (int)count;

        string a;
        a = this.InternIntern.StringCreate(data, k);

        Extern.String_Final(u);
        Extern.String_Delete(u);

        Extern.Delete(data);
        return a;
    }
}