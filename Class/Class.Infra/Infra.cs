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

    public virtual bool CheckRange(int totalCount, int start, int end)
    {
        int count;
        count = this.Count(start, end);
        return this.InfraInfra.CheckRange(totalCount, start, count);
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

    public virtual Table TableCreateRefCompare()
    {
        Table a;
        a = new Table();
        a.Compare = new RefCompare();
        a.Compare.Init();
        a.Init();
        return a;
    }

    public virtual ModuleRef ModuleRefCreate(string name, long version)
    {
        ModuleRef a;
        a = new ModuleRef();
        a.Init();
        a.Name = name;
        a.Version = version;
        return a;
    }

    public virtual Array TextCreate(string o)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        char newLine;
        newLine = this.NewLine[0];

        int count;
        count = 0;

        int oo;
        oo = o.IndexOf(newLine, 0);
        while (!(oo < 0))
        {
            count = count + 1;
            oo = o.IndexOf(newLine, oo + 1);
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

        int i;
        i = 0;
        while (i < count)
        {
            oo = o.IndexOf(newLine, index);

            int k;
            k = oo - index;

            range.Index = index;
            range.Count = k;

            Text line;
            line = textInfra.TextCreateString(o, range);
            text.Set(i, line);

            index = oo + 1;

            i = i + 1;
        }

        int ka;
        ka = o.Length - index;

        range.Index = index;
        range.Count = ka;

        Text lastLine;
        lastLine = textInfra.TextCreateString(o, range);
        text.Set(count, lastLine);

        return text;
    }

    public virtual bool SystemInfoAssignValue(SystemInfo a, SystemInfo b)
    {
        a.Value = b.Value;
        a.HasNull = b.HasNull;
        return true;
    }
}