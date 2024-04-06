namespace Avalon.Console;

public class StringIn : In
{
    public virtual string String { get; set; }

    protected virtual int Index { get; set; }

    public override string Read()
    {
        string o;
        o = this.String;
        int index;
        index = this.Index;

        string a;
        a = null;

        int u;
        u = o.IndexOf('\n', index);

        bool b;
        b = (u < 0);
        if (b)
        {
            a = o.Substring(index);
            index = index + a.Length;
        }
        if (!b)
        {
            int count;
            count = u - index;
            a = o.Substring(index, count);
            index = index + count + 1;
        }

        this.Index = index;

        return a;
    }

    public virtual bool Reset()
    {
        this.Index = 0;
        return true;
    }
}