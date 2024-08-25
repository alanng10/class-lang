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

        this.CharLess = new LessInt();
        this.CharLess.Init();

        this.CharForm = new CharForm();
        this.CharForm.Init();

        this.TextLess = new TextLess();
        this.TextLess.CharLess = this.CharLess;
        this.TextLess.LiteCharForm = this.CharForm;
        this.TextLess.RiteCharForm = this.CharForm;
        this.TextLess.Init();

        this.Range = new Range();
        this.Range.Init();
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
    public virtual TextLess TextLess { get; set; }
    public virtual LessInt CharLess { get; set; }
    public virtual CharForm CharForm { get; set; }
    public virtual Range Range { get; set; }

    public virtual Infra Add(String a)
    {
        this.InfraInfra.AddString(this.StringJoin, a);
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

    public virtual Table TableCreateStringLess()
    {
        StringLess less;
        less = this.InfraInfra.StringLessCreate();

        Table a;
        a = new Table();
        a.Less = less;
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

    public virtual long StringCount(String o)
    {
        return this.StringComp.Count(o);
    }

    public virtual String StringCreateRange(String o, long index, long count)
    {
        this.Range.Index = index;
        this.Range.Count = count;

        return this.StringComp.CreateString(o, this.Range);
    }

    public virtual String StringCreateIndex(String o, long index)
    {
        long count;
        count = this.StringCount(o) - index;
        
        return this.StringCreateRange(o, index, count);
    }

    public virtual Array TextLimitLineString(String text)
    {
        Text k;
        k = this.TextCreate(text);
        
        Array array;
        array = this.TextLimitLine(k);

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

    public virtual Array TextLimitLine(Text text)
    {
        return this.TextLimit(text, this.TextNewLine);
    }

    public virtual Text TextLower(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        long index;
        index = text.Range.Index;
        long count;
        count = text.Range.Count;

        Text a;
        a = textInfra.TextCreate(count);

        Data source;
        Data dest;
        source = text.Data;
        dest = a.Data;

        long i;
        i = 0;
        while (i < count)
        {
            uint n;
            n = textInfra.DataCharGet(source, index + i);

            if (textInfra.IsLetter(n, true))
            {
                n = n - 'A' + 'a';
            }

            textInfra.DataCharSet(dest, i, n);

            i = i + 1;
        }

        return a;
    }

    public virtual bool TextStart(Text text, Text other)
    {
        return this.TextInfra.Start(text, other, this.TextLess);
    }

    public virtual bool TextEnd(Text text, Text other)
    {
        return this.TextInfra.End(text, other, this.TextLess);
    }

    public virtual bool TextSame(Text text, Text other)
    {
        return this.TextInfra.Equal(text, other, this.TextLess);
    }

    public virtual long TextIndex(Text text, Text other)
    {
        return this.TextInfra.Index(text, other, this.TextLess);
    }

    public virtual Array TextLimit(Text text, Text delimit)
    {
        return this.TextInfra.Limit(text, delimit, this.TextLess);
    }

    public virtual Text TextReplace(Text text, Text delimit, Text join)
    {
        return this.TextInfra.Replace(text, delimit, join, this.TextLess);
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

        if (!this.TextInfra.Equal(k, ka, this.TextLess))
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