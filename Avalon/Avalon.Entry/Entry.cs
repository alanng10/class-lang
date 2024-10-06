namespace Avalon.Entry;

public class Entry : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    private StorageComp StorageComp { get; set; }
    private string[] InternArg { get; set; }

    public virtual int Execute()
    {
        this.MainBefore();

        long o;
        o = this.ExecuteMain();

        this.MainAfter();

        int a;
        a = (int)o;
        return a;
    }

    protected virtual bool MainBefore()
    {
        string kk;
        kk = Directiory.GetCurrentDirectory();
        
        kk = this.SlashCombine(kk);

        this.InternIntern.ExecuteFoldPath = this.S(kk);

        string k;
        k = typeof(Any).Assembly.Location;
        string ka;
        ka = Path.GetDirectoryName(k);

        Directiory.SetCurrentDirectory(ka);

        ka = this.SlashCombine(ka);

        this.InternIntern.ModuleFoldPath = this.S(ka);

        ulong ua;
        ua = 1;
        Extern.Main_IsCSharpSet(ua);
        Extern.Main_Init();

        ThreadThread o;
        o = new ThreadThread();
        o.InitMainThread();

        this.TextStringValue = TextStringValue.This;
        this.StorageComp = StorageComp.This;

        this.StorageComp.CurrentFoldSet(this.StorageComp.ModuleFoldPath);

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

    protected virtual string SlashCombine(string path)
    {
        string a;
        a = path.Replace('\\', '/');
        return a;
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