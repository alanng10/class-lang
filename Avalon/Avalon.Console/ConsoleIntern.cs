namespace Avalon.Console;

class ConsoleIntern : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.Intern = Extern.Console_New();
        Extern.Console_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Console_Final(this.Intern);
        Extern.Console_Delete(this.Intern);
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
        ulong uu;
        uu = Extern.Console_InnRead(this.Intern);

        ulong internReturn;
        internReturn = Extern.Return_New();
        Extern.Return_Init(internReturn);

        Extern.Return_StringSet(internReturn, uu);

        Extern.Return_StringStart(internReturn);
        ulong countU;
        countU = Extern.Return_StringCount(internReturn);
        ulong byteCount;
        byteCount = countU * 2;
        ulong data;
        data = Extern.New(byteCount);
        ulong u;
        u = Extern.String_New();
        Extern.String_Init(u);
        Extern.String_CountSet(u, countU);
        Extern.String_DataSet(u, data);
        Extern.Return_StringResult(internReturn, u);
        Extern.Return_StringEnd(internReturn);

        Extern.Return_StringSet(internReturn, 0);

        Extern.Return_Final(internReturn);
        Extern.Return_Delete(internReturn);

        int count;
        count = (int)countU;
        string a;
        a = this.InternIntern.StringCreate(data, count);

        Extern.String_Final(u);
        Extern.String_Delete(u);

        Extern.Delete(data);
        return a;
    }
}