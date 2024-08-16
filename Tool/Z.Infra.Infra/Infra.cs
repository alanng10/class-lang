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
        k = this.TextInfra.TextCreateStringData(text, null);
        
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
            a = this.TextInfra.StringCreate(ka);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    public virtual Array TextSplitLine(Text text)
    {
        return this.TextSplit(text, this.TextNewLine);
    }

    public virtual Array TextSplit(Text text, Text delimit)
    {
        return this.TextInfra.Split(text, delimit, this.TextCompare);
    }

    public virtual Text TextReplace(Text text, Text delimit, Text join)
    {
        return this.TextInfra.Replace(text, delimit, join, this.TextCompare);
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