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
        this.CountList = CountList.This;

        this.Quote = this.S("\"");
        this.BackSlash = this.S("\\");
        this.NewLine = this.S("\n");
        this.IntSignValueNegativeMax = this.InfraInfra.IntCapValue / 2;
        this.IntSignValuePositiveMax = this.IntSignValueNegativeMax - 1;
        return true;
    }

    public virtual String Quote { get; set; }
    public virtual String BackSlash { get; set; }
    public virtual String NewLine { get; set; }
    public virtual String Dot { get; set; }
    public virtual long IntSignValuePositiveMax { get; set; }
    public virtual long IntSignValueNegativeMax { get; set; }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringValue StringValue { get; set; }
    protected virtual CountList CountList { get; set; }

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
        return this.InfraInfra.ValidRange(totalCount, start, count);
    }

    public virtual Table TableCreateStringCompare()
    {
        StringLess compare;
        compare = this.InfraInfra.StringCompareCreate();
        
        Table a;
        a = new Table();
        a.Less = compare;
        a.Init();
        return a;
    }

    public virtual Table TableCreateModuleRefCompare()
    {
        Table a;
        a = new Table();
        a.Less = new ModuleRefLess();
        a.Less.Init();
        a.Init();
        return a;
    }

    public virtual Table TableCreateRefCompare()
    {
        Table a;
        a = new Table();
        a.Less = new RefLess();
        a.Less.Init();
        a.Init();
        return a;
    }

    public virtual ModuleRef ModuleRefCreate(String name, long version)
    {
        ModuleRef a;
        a = new ModuleRef();
        a.Init();
        a.Name = name;
        a.Version = version;
        return a;
    }

    public virtual String VersionString(long o)
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

        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();

        Format format;
        format = new Format();
        format.Init();
        format.CharForm = charForm;

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

        arg.Value.Int = revision;

        format.ExecuteArgCount(arg);

        Text aa;
        aa = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, aa);

        String oa;
        oa = this.TextInfra.StringCreate(aa);

        arg.Value.Int = minor;

        format.ExecuteArgCount(arg);

        Text ab;
        ab = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, ab);

        String ob;
        ob = this.TextInfra.StringCreate(ab);

        arg.FieldWidth = 1;
        arg.MaxWidth = -1;
        arg.Value.Int = major;

        format.ExecuteArgCount(arg);

        Text ac;
        ac = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, ac);

        String oc;
        oc = this.TextInfra.StringCreate(ac);

        String dot;
        dot = this.Dot;

        StringJoin h;
        h = new StringJoin();
        h.Init();

        this.Add(h, oc).Add(h, dot).Add(h, ob).Add(h, dot).Add(h, oa);

        String a;
        a = h.Result();
        return a;
    }

    public virtual bool ValidClass(Class varClass, Class requiredClass, Class anyClass, Class nullClass)
    {
        Class thisClass;
        thisClass = varClass;

        if (thisClass == nullClass)
        {
            return true;
        }

        bool b;
        b = false;
        while (!b & !(thisClass == null))
        {
            if (thisClass == requiredClass)
            {
                b = true;
            }

            Class k;
            k = null;
            if (!(thisClass == anyClass))
            {
                k = thisClass.Base;
            }
            thisClass = k;
        }

        bool a;
        a = b;
        return a;
    }

    public virtual bool ValidCount(Class thisClass, Class triggerClass, Class varClass, Count count, Class anyClass, Class nullClass)
    {
        CountList countList;
        countList = this.CountList;

        if (count == countList.Prusate)
        {
            return true;
        }

        if (count == countList.Precate)
        {
            if (this.ValidClass(thisClass, triggerClass, anyClass, nullClass))
            {
                return true;
            }
            return false;
        }

        if (count == countList.Pronate)
        {
            if (thisClass.Module == varClass.Module)
            {
                return true;
            }
            return false;
        }

        if (count == countList.Private)
        {
            if (triggerClass == varClass)
            {
                if (thisClass == triggerClass)
                {
                    return true;
                }
            }
            return false;
        }
        return true;
    }

    public virtual object CompDefined(Class varClass, string name, Class anyClass)
    {
        Count privateCount;
        privateCount = this.CountList.Private;

        object k;
        k = null;

        bool b;
        b = false;

        Class c;
        c = varClass;

        while (!b & !(c == null))
        {
            if (!b)
            {
                Field field;
                field = (Field)c.Field.Get(name);

                if (!(field == null))
                {
                    if (!(field.Count == privateCount))
                    {
                        k = field;
                        b = true;
                    }
                }
            }

            if (!b)
            {
                Maide maide;
                maide = (Maide)c.Maide.Get(name);

                if (!(maide == null))
                {
                    if (!(maide.Count == privateCount))
                    {
                        k = maide;
                        b = true;
                    }
                }
            }

            if (!b)
            {
                Class aa;
                aa = null;
                if (!(c == anyClass))
                {
                    aa = c.Base;
                }
                c = aa;
            }
        }

        return k;
    }

    private String S(string o)
    {
        return this.StringValue.Execute(o);
    }

    private Infra Add(StringJoin h, String o)
    {
        this.InfraInfra.StringJoinString(h, o);

        return this;
    }
}