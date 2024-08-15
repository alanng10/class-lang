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

    public virtual long Execute()
    {
        this.MainBefore();

        long o;
        o = this.ExecuteMain();

        this.MainAfter();
        return o;
    }

    protected virtual bool MainBefore()
    {
        string kk;
        kk = Directiory.GetCurrentDirectory();
        
        kk = this.SlashCombine(kk);

        this.InternIntern.ExecuteFoldPath = kk;

        string k;
        k = typeof(Any).Assembly.Location;
        string ka;
        ka = Path.GetDirectoryName(k);

        Directiory.SetCurrentDirectory(ka);

        ka = this.SlashCombine(ka);

        this.InternIntern.ModuleFoldPath = ka;

        //Environment.SetEnvironmentVariable("QT_PLUGIN_PATH", "Avalon.Intern.data/Lib");

        ulong ua;
        ua = 1;
        Extern.Main_IsCSharpSet(ua);
        Extern.Main_Init();

        ThreadThread o;
        o = new ThreadThread();
        o.InitMainThread();
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
        long count;
        count = arg.Length;
        Array array;
        array = new Array();
        array.Count = count;
        array.Init();
        long i;
        i = 0;
        while (i < count)
        {
            string a;
            a = arg[i];

            array.SetAt(i, a);
            i = i + 1;
        }
        this.Arg = array;
        return true;
    }
}