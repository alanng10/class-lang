namespace Avalon.Console;

public class Console : Any
{
    public static Console This { get; } = ShareCreate();

    private static Console ShareCreate()
    {
        Console share;
        share = new Console();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.InternReturn = Extern.Return_New();
        Extern.Return_Init(this.InternReturn);
        this.Intern = Extern.Console_New();
        Extern.Console_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Console_Final(this.Intern);
        Extern.Console_Delete(this.Intern);

        Extern.Return_Final(this.InternReturn);
        Extern.Return_Delete(this.InternReturn);
        return true;
    }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternReturn { get; set; }

    public virtual bool Write(string a)
    {
        ulong uo;
        uo = this.InternInfra.StringCreate(a);
        
        Extern.Console_Write(this.Intern, uo);

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
        uu = Extern.Console_Read(this.Intern);

        Extern.Return_StringSet(this.InternReturn, uu);

        Extern.Return_StringStart(this.InternReturn);
        ulong countU;
        countU = Extern.Return_StringCount(this.InternReturn);
        ulong byteCount;
        byteCount = countU * 2;
        ulong data;
        data = Extern.New(byteCount);
        ulong u;
        u = Extern.String_New();
        Extern.String_Init(u);
        Extern.String_CountSet(u, countU);
        Extern.String_DataSet(u, data);
        Extern.Return_StringResult(this.InternReturn, u);
        Extern.Return_StringEnd(this.InternReturn);

        Extern.Return_StringSet(this.InternReturn, 0);

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