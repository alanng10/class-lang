namespace Avalon.Exe;

public class Exe : Any
{
    public virtual int Execute()
    {
        return 0;
    }
    
    public virtual Array Arg
    {
        get; set;
    }

    public virtual bool SetArg(string[] arg)
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