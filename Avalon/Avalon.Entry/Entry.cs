namespace Avalon.Entry;

public class Entry : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternInfra = InternInfra.This;
        return true;
    }

    private InternInfra InternInfra { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    private StorageComp StorageComp { get; set; }
    private string[] InternArg { get; set; }

    public virtual int Execute()
    {
        this.MainBefore();

        long k;
        k = this.ExecuteMain();

        this.MainAfter();

        k = this.StatusWrite(k);

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
        ThreadThread o;
        o = new ThreadThread();
        o.InitMainThread();

        this.TextStringValue = TextStringValue.This;

        this.StorageComp = StorageComp.This;

        String kk;
        kk = this.StorageComp.ThisFoldGet();

        this.InternInfra.ModuleFoldPath = kk;

        this.StorageComp.ModuleFoldPath = kk;

        SystemConsole.OutputEncoding = System.Text.Encoding.UTF8;

        this.ArrayArg();
        return true;
    }

    protected virtual bool MainAfter()
    {
        return true;
    }

    protected virtual long ExecuteMain()
    {
        return 0;
    }

    protected virtual bool ArrayArg()
    {
        long count;
        count = this.InternArg.LongLength;

        Array array;
        array = new Array();
        array.Count = count;
        array.Init();

        long i;
        i = 0;
        while (i < count)
        {
            string ka;
            ka = this.InternArg[i];

            String a;
            a = this.S(ka);

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