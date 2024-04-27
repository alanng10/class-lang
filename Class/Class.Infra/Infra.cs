namespace Class.Infra;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.Quote = "\"";
        this.BackSlash = "\\";
        this.Tab = "\t";
        this.NewLine = "\n";
        this.IntSignValueNegativeMax = this.InfraInfra.IntCapValue / 2;
        this.IntSignValuePositiveMax = this.IntSignValueNegativeMax - 1;
        return true;
    }

    public virtual string Quote { get; set; }
    public virtual string BackSlash { get; set; }
    public virtual string Tab { get; set; }
    public virtual string NewLine { get; set; }
    public virtual long IntSignValuePositiveMax { get; set; }
    public virtual long IntSignValueNegativeMax { get; set; }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }

    public virtual bool IndexRange(Range range, int index)
    {
        range.Start = index;
        range.End = index + 1;
        return true;
    }

    public virtual int Count(int start, int end)
    {
        return end - start;
    }

    public virtual bool CheckRange(int count, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;
        if (start < 0)
        {
            return false;
        }
        if (end < start)
        {
            return false;
        }
        if (count < end)
        {
            return false;
        }
        return true;
    }

    public virtual bool Equal(Text text, string o)
    {
        if (!this.TextInfra.CheckRange(text))
        {
            return false;
        }

        int count;
        count = text.Range.Count;
        if (!(count == o.Length))
        {
            return false;
        }

        int start;
        start = text.Range.Index;
        int index;
        char oca;
        char ocb;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + i;

            oca = this.TextInfra.DataCharGet(text.Data, index);
            ocb = o[i];
            if (!(oca == ocb))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    public virtual Table TableCreateStringCompare()
    {
        Table a;
        a = new Table();
        a.Compare = new StringCompare();
        a.Compare.Init();
        a.Init();
        return a;
    }

    public virtual Table TableCreateModuleRefCompare()
    {
        Table a;
        a = new Table();
        a.Compare = new ModuleRefCompare();
        a.Compare.Init();
        a.Init();
        return a;
    }

    public virtual ModuleRef ModuleRefCreate(string name, long ver)
    {
        ModuleRef a;
        a = new ModuleRef();
        a.Init();
        a.Name = name;
        a.Version = ver;
        return a;
    }

    public virtual Array TextCreate(string o)
    {
        int count;
        count = 0;

        int oo;
        oo = o.IndexOf('\n', 0);
        while (!(oo < 0))
        {
            count = count + 1;
            oo = o.IndexOf('\n', oo + 1);
        }

        Array text;
        text = new Array();
        text.Count = count + 1;
        text.Init();

        InfraRange range;
        range = new InfraRange();
        range.Init();

        int index;
        index = 0;

        oo = o.IndexOf('\n', index);
        int i;
        i = 0;
        while (i < count)
        {
            int k;
            k = oo - index;

            range.Index = index;
            range.Count = k;

            Text line;
            line = this.TextInfra.TextCreateString(o, range);
            text.Set(i, line);

            index = oo + 1;

            oo = o.IndexOf('\n', index);

            i = i + 1;
        }

        int ka;
        ka = o.Length - index;

        range.Index = index;
        range.Count = ka;

        Text lastLine;
        lastLine = this.TextInfra.TextCreateString(o, range);
        text.Set(count, lastLine);

        return text;
    }
}