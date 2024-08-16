namespace Z.Infra.Infra;

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
        this.StorageInfra = StorageInfra.This;
        this.StringComp = StringComp.This;
        this.StringValue = StringValue.This;
        this.Console = Console.This;

        this.StringJoin = new StringJoin();
        this.StringJoin.Init();

        this.NewLine = this.StringComp.CreateChar('\n', 1);
        this.Indent = this.StringComp.CreateChar(' ', 4);

        this.TextNewLine = this.TextInfra.TextCreateStringData(this.NewLine, null);

        this.CharCompare = new CompareInt();
        this.CharCompare.Init();

        this.CharForm = new CharForm();
        this.CharForm.Init();

        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = this.CharCompare;
        this.TextCompare.LeftCharForm = this.CharForm;
        this.TextCompare.RightCharForm = this.CharForm;
        this.TextCompare.Init();
        return true;
    }

    public virtual Text TextNewLine { get; set; }
    public virtual String NewLine { get; set; }
    public virtual String Indent { get; set; }
    public virtual InfraInfra InfraInfra { get; set; }
    public virtual TextInfra TextInfra { get; set; }
    public virtual StorageInfra StorageInfra { get; set; }
    public virtual StringComp StringComp { get; set; }
    public virtual StringValue StringValue { get; set; }
    public virtual Console Console { get; set; }
    public virtual StringJoin StringJoin { get; set; }
    public virtual TextCompare TextCompare { get; set; }
    public virtual CompareInt CharCompare { get; set; }
    public virtual CharForm CharForm { get; set; }

    public virtual Infra Add(String a)
    {
        this.InfraInfra.StringJoinString(this.StringJoin, a);
        return this;
    }

    public virtual Infra AddChar(uint a)
    {
        this.StringJoin.Add(a);
        return this;
    }

    public virtual Infra AddValue(string o)
    {
        return this.Add(this.S(o));
    }

    public virtual Infra AddClear()
    {
        this.StringJoin.Clear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.StringJoin.Result();
    }

    public virtual Infra AddIndent(long indent)
    {
        long count;
        count = indent;
        long i;
        i = 0;
        while (i < count)
        {
            this.Add(this.Indent);
            i = i + 1;
        }
        return this;
    }

    public virtual Table TableCreateStringCompare()
    {
        StringCompare compare;
        compare = this.InfraInfra.StringCompareCreate();

        Table a;
        a = new Table();
        a.Compare = compare;
        a.Init();
        return a;
    }

    public virtual String StorageTextRead(String filePath)
    {
        String a;
        a = this.StorageInfra.TextReadAny(filePath, true);

        if (a == null)
        {
            this.Console.Err.Write(this.S("Text File Read Error path: " + filePath + "\n"));
            global::System.Environment.Exit(300);
        }
        return a;
    }

    public virtual bool StorageTextWrite(String filePath, String text)
    {
        bool a;
        a = this.StorageInfra.TextWriteAny(filePath, text, true);

        if (!a)
        {
            this.Console.Err.Write(this.S("Text File Write Error path: " + filePath + "\n"));
            global::System.Environment.Exit(301);
        }
        return a;
    }

    public virtual Array TextSplit(Text text, Text delimit)
    {
        Array array;
        array = this.TextInfra.TextArraySplit(text, delimit, this.TextCompare);
        return array;
    }

    public virtual Text TextArrayJoin(Array array, Text join)
    {
        long k;
        k = 0;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Text ka;
            ka = (Text)array.GetAt(i);

            if (0 < i)
            {
                k = k + join.Range.Count;
            }

            k = k + ka.Range.Count;

            i = i + 1;
        }

        Text text;
        text = this.TextInfra.TextCreate(k);
        
        k = 0;
        i = 0;
        while (i < count)
        {
            Text ka;
            ka = (Text)array.GetAt(i);

            if (0 < i)
            {
                k = k + join.Range.Count;
            }

            k = k + ka.Range.Count;

            i = i + 1;
        }

        return text;
    }

    public virtual bool DataCopy(Data dest, long destIndex, Data source, long sourceIndex, long count)
    {
        long i;
        i = 0;
        while (i < count)
        {
            long n;
            n = source.Get(sourceIndex + i);

            dest.Set(destIndex + i, n);

            i = i + 1;
        }
        return true;
    }

    public virtual bool GetBool(string a)
    {
        bool b;
        b = false;
        if (!(a == "false"))
        {
            b = true;
        }
        return b;
    }

    public virtual string GetBoolString(bool a)
    {
        string u;
        u = "false";
        if (a)
        {
            u = "true";
        }
        return u;
    }

    public virtual String S(string o)
    {
        return this.StringValue.Execute(o);
    }
}