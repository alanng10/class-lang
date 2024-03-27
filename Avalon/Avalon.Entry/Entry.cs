namespace Avalon.Entry;

public class Entry : Any
{
    public virtual int Execute()
    {
        return 0;
    }
    
    public virtual Array Arg
    {
        get; set;
    }

    public virtual bool ArgSet(object arg)
    {
        string[] ua;
        ua = (string[])arg;

        int count;
        count = ua.Length;
        Array array;
        array = new Array();
        array.Count = count;
        array.Init();
        int i;
        i = 0;
        while (i < count)
        {
            string a;
            a = ua[i];

            array.Set(i, a);
            i = i + 1;
        }
        this.Arg = array;
        return true;
    }
}