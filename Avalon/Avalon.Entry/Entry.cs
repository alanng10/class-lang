namespace Avalon.Entry;

public class Entry : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = Intern.This;
        this.InternInfra = InternInfra.This;
        return true;
    }

    private Intern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    private StorageComp StorageComp { get; set; }
    private string[] InternArg { get; set; }

    public virtual int Execute()
    {
        this.MainBefore();

        long k;
        k = this.ExecuteMain();

        k = this.StatusWrite(k);

        this.MainAfter();

        int a;
        a = (int)k;
        return a;
    }

    protected virtual long StatusWrite(long value)
    {
        long k;
        k = value;

        if (!(k == 0))
        {
            ConsoleConsole ka;
            ka = new ConsoleConsole();
            ka.Init();

            ka.Err.Write(TextCreate.This.Add().AddS("Status: ").AddInt(k).AddLine().AddResult());

            k = 1;
        }

        return k;
    }

    protected virtual bool MainBefore()
    {
        ulong ua;
        ua = 1;
        Extern.Main_IsCSharpSet(ua);
        Extern.Main_Init(1, 0);

        ThreadThread o;
        o = new ThreadThread();
        o.InitMainThread();

        this.TextStringValue = TextStringValue.This;

        this.StorageComp = StorageComp.This;

        String kk;
        kk = this.StorageComp.ThisFoldGet();

        this.InternInfra.ModuleFoldPath = kk;

        this.StorageComp.ModuleFoldPath = kk;

        this.ArrayArg();
        return true;
    }

    protected virtual bool MainAfter()
    {
        Extern.Main_Final();
        return true;
    }

    protected virtual long ExecuteMain()
    {
        return 0;
    }

    protected virtual bool ArrayArg()
    {
        string[] ao;
        ao = this.InternArg;

        long count;
        count = ao.LongLength;
        Array array;
        array = new Array();
        array.Count = count;
        array.Init();
        long i;
        i = 0;
        while (i < count)
        {
            string ku;
            ku = ao[i];

            String a;
            a = this.S(ku);

            array.SetAt(i, a);
            i = i + 1;
        }
        this.Arg = array;

        return true;
    }

    public virtual Array Arg
    {
        get; set;
    }

    public virtual bool ArgSet(string[] arg)
    {
        this.InternArg = arg;
        return true;
    }

    protected virtual String S(string o)
    {
        return this.TextStringValue.Execute(o);
    }
}