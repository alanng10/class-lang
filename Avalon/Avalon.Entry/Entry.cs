namespace Avalon.Entry;

public class Entry : Any
{
    public virtual int Execute()
    {
        this.MainBefore();

        int o;
        o = this.Main();

        this.MainAfter();
        return o;
    }

    protected virtual bool MainBefore()
    {
        string k;
        k = typeof(Any).Assembly.Location;
        string ka;
        ka = Path.GetDirectoryName(k);

        Directiory.SetCurrentDirectory(ka);

        Environment.SetEnvironmentVariable("QT_PLUGIN_PATH", "Avalon.Intern.data/Lib");

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

    protected virtual int Main()
    {
        return 0;
    }
    
    public virtual Array Arg
    {
        get; set;
    }

    public virtual bool ArgSet(string[] arg)
    {
        int count;
        count = arg.Length;
        Array array;
        array = new Array();
        array.Count = count;
        array.Init();
        int i;
        i = 0;
        while (i < count)
        {
            string a;
            a = arg[i];

            array.Set(i, a);
            i = i + 1;
        }
        this.Arg = array;
        return true;
    }
}