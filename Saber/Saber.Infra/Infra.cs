namespace Saber.Infra;

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

        this.TextNewLine = this.S("\n");
        this.TextHash = this.S("#");
        this.TextSpace = this.S(" ");
        this.TextQuote = this.S("\"");
        this.TextNext = this.S("\\");
        this.TextAlphaN = this.S("n");
        this.TextAlphaU = this.S("u");
        this.TextLine = this.S("_");
        this.TextDot = this.S(".");
        this.TextHyphen = this.S("-");
        this.TextModule = this.S("Module");
        this.TextImport = this.S("Import");
        this.TextExport = this.S("Export");
        this.TextStorage = this.S("Storage");
        this.TextEntry = this.S("Entry");
        this.IntSignNegateMax = this.InfraInfra.IntCapValue / 2;
        this.IntSignPositeMax = this.IntSignNegateMax - 1;
        return true;
    }

    public virtual String TextNewLine { get; set; }
    public virtual String TextHash { get; set; }
    public virtual String TextSpace { get; set; }
    public virtual String TextQuote { get; set; }
    public virtual String TextNext { get; set; }
    public virtual String TextAlphaN { get; set; }
    public virtual String TextAlphaU { get; set; }
    public virtual String TextLine { get; set; }
    public virtual String TextDot { get; set; }
    public virtual String TextHyphen { get; set; }
    public virtual String TextModule { get; set; }
    public virtual String TextImport { get; set; }
    public virtual String TextExport { get; set; }
    public virtual String TextStorage { get; set; }
    public virtual String TextEntry { get; set; }
    public virtual long IntSignPositeMax { get; set; }
    public virtual long IntSignNegateMax { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual CountList CountList { get; set; }

    public virtual bool IndexRange(Range range, long index)
    {
        range.Start = index;
        range.End = index + 1;
        return true;
    }

    public virtual long Count(long start, long end)
    {
        return end - start;
    }

    public virtual bool ValidRange(long totalCount, long start, long end)
    {
        long count;
        count = this.Count(start, end);
        return this.InfraInfra.ValidRange(totalCount, start, count);
    }

    public virtual Table TableCreateStringLess()
    {
        StringLess less;
        less = this.TextInfra.StringLessCreate();

        Table a;
        a = new Table();
        a.Less = less;
        a.Init();
        return a;
    }

    public virtual Table TableCreateModuleRefLess()
    {
        Table a;
        a = new Table();
        a.Less = new ModuleRefLess();
        a.Less.Init();
        a.Init();
        return a;
    }

    public virtual Table TableCreateRefLess()
    {
        Table a;
        a = new Table();
        a.Less = new RefLess();
        a.Less.Init();
        a.Init();
        return a;
    }

    public virtual ModuleRef ModuleRefCreate(String name, long ver)
    {
        ModuleRef a;
        a = new ModuleRef();
        a.Init();
        a.Name = name;
        a.Ver = ver;
        return a;
    }

    public virtual String ModuleRefString(String name, String verString)
    {
        StringAdd k;
        k = new StringAdd();
        k.Init();

        this.Add(k, name).Add(k, this.TextHyphen).Add(k, verString);

        String a;
        a = k.Result();
        return a;
    }

    public virtual String VerString(long value)
    {
        long kf;
        kf = this.InfraInfra.IntCapValue - 1;

        value = value & kf;

        long revise;
        revise = value & 0xff;

        long minor;
        minor = (value >> 8) & 0xff;

        long major;
        major = value >> 16;

        Format format;
        format = new Format();
        format.Init();

        FormatArg arg;
        arg = new FormatArg();
        arg.Init();

        arg.Kind = 1;
        arg.Base = 10;
        arg.AlignLeft = false;
        arg.FieldWidth = 2;
        arg.MaxWidth = 2;
        arg.FillChar = '0';

        Text kd;

        arg.Value.Int = revise;

        format.ExecuteArgCount(arg);

        kd = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, kd);

        String ka;
        ka = this.TextInfra.StringCreate(kd);

        arg.Value.Int = minor;

        format.ExecuteArgCount(arg);

        kd = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, kd);

        String kb;
        kb = this.TextInfra.StringCreate(kd);

        arg.FieldWidth = 1;
        arg.MaxWidth = -1;
        arg.Value.Int = major;

        format.ExecuteArgCount(arg);

        kd = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, kd);

        String kc;
        kc = this.TextInfra.StringCreate(kd);

        String dot;
        dot = this.TextDot;

        StringAdd kk;
        kk = new StringAdd();
        kk.Init();

        this.Add(kk, kc).Add(kk, dot).Add(kk, kb).Add(kk, dot).Add(kk, ka);

        String a;
        a = kk.Result();
        return a;
    }

    public virtual long BaseCount(Class varClass, Class anyClass)
    {
        Class kk;
        kk = varClass;

        long k;
        k = 0;

        while (!(kk == null))
        {
            k = k + 1;

            Class ka;
            ka = null;
            if (!(kk == anyClass))
            {
                ka = kk.Base;
            }
            kk = ka;
        }

        return k;
    }

    public virtual bool CompDefine(Class varClass, String name)
    {
        bool ba;
        ba = varClass.Field.Valid(name);
        bool bb;
        bb = varClass.Maide.Valid(name);

        bool a;
        a = ba | bb;
        return a;
    }

    public virtual bool ValidClass(Class varClass, Class requireClass, Class anyClass, Class nullClass)
    {
        Class k;
        k = varClass;

        if (k == nullClass)
        {
            return true;
        }

        bool b;
        b = false;
        while (!b & !(k == null))
        {
            if (k == requireClass)
            {
                b = true;
            }

            if (!b)
            {
                Class ka;
                ka = null;
                if (!(k == anyClass))
                {
                    ka = k.Base;
                }
                k = ka;
            }
        }

        bool a;
        a = b;
        return a;
    }

    public virtual bool ValidCount(Class thisClass, Class triggClass, Class varClass, Count count, Class anyClass, Class nullClass)
    {
        CountList countList;
        countList = this.CountList;

        if (count == countList.Prusate)
        {
            return true;
        }

        if (count == countList.Precate)
        {
            if (this.ValidClass(thisClass, triggClass, anyClass, nullClass))
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
            if (thisClass == triggClass)
            {
                return true;
            }
            return false;
        }
        return true;
    }

    public virtual bool VirtualField(Field a)
    {
        ClassClass varClass;
        varClass = a.Parent;

        if (varClass == this.System.Any)
        {
            return true;
        }

        object ka;
        ka = this.ClassInfra.VirtualDefine(varClass.Base, a.Name, this.Module, this.System.Any);

        if (ka == null)
        {
            return true;
        }

        Field k;
        k = ka as Field;

        if (k == null)
        {
            return false;
        }

        bool b;
        b = false;

        if (!b)
        {
            if (!(a.Class == k.Class))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(a.Count == k.Count))
            {
                b = true;
            }
        }

        if (b)
        {
            return false;
        }

        Field h;
        h = k;
        if (!(k.Virtual == null))
        {
            h = k.Virtual;
        }

        a.Virtual = h;
        return true;
    }

    public virtual bool VirtualMaide(Maide a)
    {
        ClassClass varClass;
        varClass = a.Parent;

        if (varClass == this.System.Any)
        {
            return true;
        }

        object ka;
        ka = this.ClassInfra.VirtualDefine(varClass.Base, a.Name, this.Module, this.System.Any);

        if (ka == null)
        {
            return true;
        }

        Maide k;
        k = ka as Maide;

        if (k == null)
        {
            return false;
        }

        bool b;
        b = false;

        if (!b)
        {
            if (!(a.Class == k.Class))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(a.Count == k.Count))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!this.VarSameClass(a.Param, k.Param))
            {
                b = true;
            }
        }

        if (b)
        {
            return false;
        }

        Maide h;
        h = k;
        if (!(k.Virtual == null))
        {
            h = k.Virtual;
        }

        a.Virtual = h;
        return true;
    }

    public virtual bool VarSameClass(Table varA, Table varB)
    {
        if (!(varA.Count == varB.Count))
        {
            return false;
        }

        Iter iterA;
        iterA = varA.IterCreate();
        varA.IterSet(iterA);

        Iter iterB;
        iterB = varB.IterCreate();
        varB.IterSet(iterB);

        long count;
        count = varA.Count;
        long i;
        i = 0;
        while (i < count)
        {
            iterA.Next();
            iterB.Next();

            Var ka;
            Var kb;
            ka = iterA.Value as Var;
            kb = iterB.Value as Var;

            bool b;
            b = (ka.Class == kb.Class);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        return true;
    }

    public virtual object VirtualDefine(Class varClass, String name, Module module, Class anyClass)
    {
        Count prusateCount;
        Count precateCount;
        Count pronateCount;
        prusateCount = this.CountList.Prusate;
        precateCount = this.CountList.Precate;
        pronateCount = this.CountList.Pronate;

        object k;
        k = null;

        bool b;
        b = false;

        Class kk;
        kk = varClass;

        while (!b & !(kk == null))
        {
            if (!b)
            {
                Field field;
                field = kk.Field.Get(name) as Field;

                if (!(field == null))
                {
                    Count ka;
                    ka = field.Count;
                    if (ka == prusateCount | ka == precateCount)
                    {
                        k = field;
                        b = true;
                    }

                    if (ka == pronateCount)
                    {
                        if (kk.Module == module)
                        {
                            k = field;
                            b = true;
                        }
                    }
                }
            }

            if (!b)
            {
                Maide maide;
                maide = kk.Maide.Get(name) as Maide;

                if (!(maide == null))
                {
                    Count kb;
                    kb = maide.Count;
                    if (kb == prusateCount | kb == precateCount)
                    {
                        k = maide;
                        b = true;
                    }

                    if (kb == pronateCount)
                    {
                        if (kk.Module == module)
                        {
                            k = maide;
                            b = true;
                        }
                    }
                }
            }

            if (!b)
            {
                Class kd;
                kd = null;
                if (!(kk == anyClass))
                {
                    kd = kk.Base;
                }
                kk = kd;
            }
        }

        object a;
        a = k;
        return a;
    }

    public virtual String ClassModulePath(String classPath)
    {
        return classPath;
    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }

    private Infra Add(StringAdd k, String a)
    {
        this.TextInfra.AddString(k, a);
        return this;
    }

    private Infra AddClear(StringAdd k)
    {
        k.Clear();
        return this;
    }

    private String AddResult(StringAdd k)
    {
        return k.Result();
    }
}