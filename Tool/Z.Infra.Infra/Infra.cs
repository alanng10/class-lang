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

    public virtual Infra AddS(string o)
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
            String k;
            k = this.AddClear().AddS("Text File Read Error path: ").Add(filePath).AddS("\n").AddResult();

            this.Console.Err.Write(k);
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
            String k;
            k = this.AddClear().AddS("Text File Write Error path: ").Add(filePath).AddS("\n").AddResult();

            this.Console.Err.Write(k);
            global::System.Environment.Exit(301);
        }
        return a;
    }

    public virtual Array TextSplitLineString(String text)
    {
        Text k;
        k = this.TextCreate(text);
        
        Array array;
        array = this.TextSplitLine(k);

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Text ka;
            ka = (Text)array.GetAt(i);

            String a;
            a = this.StringCreate(ka);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual Array TextSplitLine(Text text)
    {
        return this.TextSplit(text, this.TextNewLine);
    }

    public virtual long TextIndex(Text text, Text other)
    {
        return this.TextInfra.Index(text, other, this.TextCompare);
    }

    public virtual Array TextSplit(Text text, Text delimit)
    {
        return this.TextInfra.Split(text, delimit, this.TextCompare);
    }

    public virtual Text TextReplace(Text text, Text delimit, Text join)
    {
        return this.TextInfra.Replace(text, delimit, join, this.TextCompare);
    }

    public virtual Text TextCreate(String o)
    {
        return this.TextInfra.TextCreateStringData(o, null);
    }

    public virtual String StringCreate(Text text)
    {
        return this.TextInfra.StringCreate(text);
    }

    public virtual Text CreateText(Data data, long index, long count)
    {
        Range range;
        range = new Range();
        range.Init();
        range.Index = index;
        range.Count = count;

        Text text;
        text = new Text();
        text.Init();
        text.Data = data;
        text.Range = range;
        return text;
    }

    public virtual bool GetBool(String a)
    {
        bool b;
        b = false;

        Text k;
        k = this.TextCreate(a);

        Text ka;
        ka = this.TextCreate(this.TextInfra.BoolFalseString);

        if (!this.TextInfra.Equal(k, ka, this.TextCompare))
        {
            b = true;
        }
        return b;
    }

    public virtual String GetBoolString(bool a)
    {
        String u;
        u = null;

        if (!a)
        {
            u = this.TextInfra.BoolFalseString;
        }
        if (a)
        {
            u = this.TextInfra.BoolTrueString;
        }
        return u;
    }

    public virtual String S(string o)
    {
        return this.StringValue.Execute(o);
    }
}