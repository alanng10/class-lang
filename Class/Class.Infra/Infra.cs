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
        
        this.CharCompare = new IntCompare();
        this.CharCompare.Init();

        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = this.CharCompare;
        this.TextCompare.Init();

        this.DotText = this.TextInfra.TextCreateStringData(".", null);
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
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual IntCompare CharCompare { get; set; }
    protected virtual Text DotText { get; set; }

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
        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();

        StringCompare compare;
        compare = new StringCompare();
        compare.CharCompare = charCompare;
        compare.Init();
        
        Table a;
        a = new Table();
        a.Compare = compare;
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

    public virtual string VersionString(long o)
    {
        long ka;
        ka = this.InfraInfra.IntCapValue - 1;

        o = o & ka;

        long revision;
        revision = o & 0xff;

        long minor;
        minor = (o >> 8) & 0xff;

        long major;
        major = o >> 16;

        Format format;
        format = new Format();
        format.Init();

        FormatArg arg;
        arg = new FormatArg();
        arg.Init();

        arg.Kind = 1;
        arg.Base = 10;
        arg.Case = 0;
        arg.AlignLeft = false;
        arg.FieldWidth = 2;
        arg.MaxWidth = 2;
        arg.FillChar = '0';

        arg.ValueInt = revision;

        format.ExecuteArgCount(arg);

        Text aa;
        aa = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, aa);

        string oa;
        oa = this.TextInfra.StringCreate(aa);

        arg.ValueInt = minor;

        format.ExecuteArgCount(arg);

        Text ab;
        ab = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, ab);

        string ob;
        ob = this.TextInfra.StringCreate(ab);

        arg.FieldWidth = 1;
        arg.MaxWidth = -1;
        arg.ValueInt = major;

        format.ExecuteArgCount(arg);

        Text ac;
        ac = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, ac);

        string oc;
        oc = this.TextInfra.StringCreate(ac);

        string dot;
        dot = ".";

        string a;
        a = major + dot + minor + dot + revision;
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

    public virtual bool IsModuleName(NameCheck nameCheck, Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Compare compare;
        compare = this.TextCompare;

        Text dot;
        dot = this.DotText;

        InfraRange range;
        range = text.Range;

        int aa;
        int ab;
        aa = range.Index;
        ab = range.Count;
        int ac;
        ac = aa + ab;

        bool b;
        b = false;

        int u;
        u = textInfra.Index(text, dot, compare);

        int index;
        int count;
        index = aa;
        count = ab;
        while (!b & !(u == -1))
        {
            count = u;
            range.Count = count;

            if (!nameCheck.IsName(text))
            {
                b = true;
            }

            if (!b)
            {
                index = index + u + 1;
                count = ac - index;

                range.Index = index;
                range.Count = count;

                u = textInfra.Index(text, dot, compare);
            }
        }

        bool ba;
        ba = false;

        if (!ba)
        {
            if (b)
            {
                ba = true;
            }
        }
        if (!ba)
        {
            count = ac - index;
            range.Count = count;

            if (!nameCheck.IsName(text))
            {
                ba = true;
            }
        }

        range.Index = aa;
        range.Count = ab;
        
        bool a;
        a = !ba;
        return a;
    }

    public virtual bool SystemInfoAssignValue(SystemInfo a, SystemInfo b)
    {
        a.Value = b.Value;
        return true;
    }
}