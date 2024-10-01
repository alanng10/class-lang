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
        this.TextCode = TextCode.This;
        this.TextCodeKindList = TextCodeKindList.This;
        this.StringValue = StringValue.This;
        this.Console = Console.This;

        this.StringAdd = this.CreateStringAdd();

        this.Write = this.CreateWrite();
        this.WriteArgInt = this.CreateWriteArgInt();
        this.WriteArgIntHex = this.CreateWriteArgIntHex();

        this.CharLess = this.CreateCharLess();
        this.TextForm = this.CreateCharForm();
        this.TextLess = this.CreateTextLess();

        this.TextA = this.CreateText();
        this.TextB = this.CreateText();
        this.TextC = this.CreateText();
        this.TextD = this.CreateText();
        this.TextAA = this.CreateText();

        this.StringDataA = this.CreateStringData();
        this.StringDataB = this.CreateStringData();
        this.StringDataC = this.CreateStringData();
        this.StringDataD = this.CreateStringData();
        this.StringDataAA = this.CreateStringData();

        this.Range = this.CreateInfraRange();

        this.Indent = this.StringComp.CreateChar(' ', 4);
        return true;
    }

    public virtual String Indent { get; set; }
    public virtual InfraInfra InfraInfra { get; set; }
    public virtual TextInfra TextInfra { get; set; }
    public virtual StorageInfra StorageInfra { get; set; }
    public virtual StringComp StringComp { get; set; }
    public virtual StringValue StringValue { get; set; }
    public virtual TextCode TextCode { get; set; }
    public virtual TextCodeKindList  TextCodeKindList { get; set; }
    public virtual Console Console { get; set; }
    public virtual StringAdd StringAdd { get; set; }
    public virtual TextLess TextLess { get; set; }
    public virtual LessInt CharLess { get; set; }
    public virtual TextForm TextForm { get; set; }
    public virtual Range Range { get; set; }
    public virtual Text TextA { get; set; }
    public virtual Text TextB { get; set; }
    public virtual Text TextC { get; set; }
    public virtual Text TextD { get; set; }
    public virtual Text TextAA { get; set; }
    public virtual StringData StringDataA { get; set; }
    public virtual StringData StringDataB { get; set; }
    public virtual StringData StringDataC { get; set; }
    public virtual StringData StringDataD { get; set; }
    public virtual StringData StringDataAA { get; set; }
    public virtual Write Write { get; set; }
    public virtual WriteArg WriteArgInt { get; set; }
    public virtual WriteArg WriteArgIntHex { get; set; }

    protected virtual StringAdd CreateStringAdd()
    {
        StringAdd a;
        a = new StringAdd();
        a.Init();
        return a;
    }

    protected virtual Write CreateWrite()
    {
        Write a;
        a = new Write();
        a.Init();
        return a;
    }

    protected virtual WriteArg CreateWriteArgInt()
    {
        WriteArg a;
        a = new WriteArg();
        a.Init();
        a.Kind = 1;
        a.Base = 10;
        a.AlignLeft = false;
        a.FieldWidth = 1;
        a.MaxWidth = -1;
        return a;
    }

    protected virtual WriteArg CreateWriteArgIntHex()
    {
        WriteArg a;
        a = new WriteArg();
        a.Init();
        a.Kind = 1;
        a.Base = 16;
        a.AlignLeft = false;
        a.FieldWidth = 15;
        a.MaxWidth = 15;
        a.FillChar = '0';
        return a;
    }


    protected virtual LessInt CreateCharLess()
    {
        LessInt a;
        a = new LessInt();
        a.Init();
        return a;
    }

    protected virtual TextForm CreateCharForm()
    {
        TextForm a;
        a = new TextForm();
        a.Init();
        return a;
    }

    protected virtual TextLess CreateTextLess()
    {
        TextLess a;
        a = new TextLess();
        a.CharLess = this.CharLess;
        a.LiteForm = this.TextForm;
        a.RiteForm = this.TextForm;
        a.Init();
        return a;
    }

    protected virtual Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new Range();
        a.Range.Init();
        return a;
    }

    protected virtual StringData CreateStringData()
    {
        StringData a;
        a = new StringData();
        a.Init();
        return a;
    }

    protected virtual Range CreateInfraRange()
    {
        Range a;
        a = new Range();
        a.Init();
        return a;
    }
    
    public virtual Text TA(String o)
    {
        return this.TextString(o, this.TextA, this.StringDataA);
    }

    public virtual Text TB(String o)
    {
        return this.TextString(o, this.TextB, this.StringDataB);
    }

    public virtual Text TC(String o)
    {
        return this.TextString(o, this.TextC, this.StringDataC);
    }

    public virtual Text TD(String o)
    {
        return this.TextString(o, this.TextD, this.StringDataD);
    }

    public virtual Text TextString(String o, Text text, StringData data)
    {
        data.ValueString = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = this.StringCount(o);
        return text;
    }

    public virtual String IntString(long n)
    {
        return this.IntStringArg(n, this.WriteArgInt);
    }

    public virtual String IntStringHex(long n)
    {
        return this.IntStringArg(n, this.WriteArgIntHex);
    }

    public virtual String IntStringArg(long n, WriteArg arg)
    {
        arg.Value.Int = n;

        this.Write.ExecuteArgCount(arg);

        Text aa;
        aa = this.TextInfra.TextCreate(arg.Count);

        this.Write.ExecuteArgResult(arg, aa);

        String a;
        a = this.StringCreate(aa);

        return a;
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

    public virtual String StorageTextRead(String filePath)
    {
        String a;
        a = this.StorageTextReadAny(filePath, true);

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
        a = this.StorageTextWriteAny(filePath, text, true);

        if (!a)
        {
            String k;
            k = this.AddClear().AddS("Text File Write Error path: ").Add(filePath).AddS("\n").AddResult();

            this.Console.Err.Write(k);
            global::System.Environment.Exit(301);
        }
        return a;
    }

    public virtual String StorageTextReadAny(String filePath, bool anyNode)
    {
        TextCodeKindList kindList;
        kindList = this.TextCodeKindList;

        Data data;
        data = this.StorageInfra.DataReadAny(filePath, anyNode);
        if (data == null)
        {
            return null;
        }

        TextCodeKind innKind;
        TextCodeKind outKind;
        innKind = kindList.Utf8;
        outKind = kindList.Utf32;

        TextCode code;
        code = this.TextCode;

        Range dataRange;
        dataRange = new Range();
        dataRange.Init();
        dataRange.Count = data.Count;

        long resultCount;
        resultCount = code.ExecuteCount(innKind, outKind, data, dataRange);

        Data result;
        result = new Data();
        result.Count = resultCount;
        result.Init();

        code.ExecuteResult(result, 0, innKind, outKind, data, dataRange);

        String k;
        k = this.StringComp.CreateData(result, null);

        String a;
        a = k;
        return a;
    }

    public virtual bool StorageTextWriteAny(String filePath, String text, bool anyNode)
    {
        TextCodeKindList kindList;
        kindList = this.TextCodeKindList;

        TextCodeKind innKind;
        TextCodeKind outKind;
        innKind = kindList.Utf32;
        outKind = kindList.Utf8;

        TextCode code;
        code = this.TextCode;

        Data data;
        data = this.TextInfra.StringDataCreateString(text);

        Range dataRange;
        dataRange = new Range();
        dataRange.Init();
        dataRange.Count = data.Count;

        long resultCount;
        resultCount = code.ExecuteCount(innKind, outKind, data, dataRange);

        Data result;
        result = new Data();
        result.Count = resultCount;
        result.Init();

        code.ExecuteResult(result, 0, innKind, outKind, data, dataRange);

        bool a;
        a = this.StorageInfra.DataWriteAny(filePath, result, anyNode);
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

    public virtual String StringCreateTextRange(Text o, long index, long count)
    {
        long aa;
        long ab;
        aa = o.Range.Index;
        ab = o.Range.Count;

        o.Range.Index = index;
        o.Range.Count = count;

        String a;
        a = this.StringCreate(o);

        o.Range.Index = aa;
        o.Range.Count = ab;

        return a;
    }

    public virtual String StringCreateTextIndex(Text o, long index)
    {
        long aa;
        long ab;
        aa = o.Range.Index;
        ab = o.Range.Count;

        o.Range.Index = index;
        o.Range.Count = aa + ab - index;

        String a;
        a = this.StringCreate(o);

        o.Range.Index = aa;
        o.Range.Count = ab;

        return a;
    }

    public virtual Array TextLimitLineString(Text text)
    {
        Array array;
        array = this.TextLimitLine(text);

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
        return this.TextLimit(text, this.TextString(this.TextInfra.NewLine, this.TextAA, this.StringDataAA));
    }

    public virtual Text TextAlphaNite(Text text)
    {
        return this.TextCreateForm(text, this.TextInfra.AlphaNiteForm);
    }

    public virtual Text TextAlphaSite(Text text)
    {
        return this.TextCreateForm(text, this.TextInfra.AlphaSiteForm);
    }

    public virtual Text TextCreateForm(Text text, TextForm form)
    {
        long count;
        count = text.Range.Count;

        Text a;
        a = this.TextInfra.TextCreate(count);

        this.TextInfra.Form(a, text, form);

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
        return this.TextInfra.Same(text, other, this.TextLess);
    }

    public virtual long TextIndex(Text text, Text other)
    {
        return this.TextInfra.Index(text, other, this.TextLess);
    }

    public virtual Array TextLimit(Text text, Text delimit)
    {
        return this.TextInfra.Limit(text, delimit, this.TextLess);
    }

    public virtual Text TextReplace(Text text, Text limit, Text join)
    {
        return this.TextInfra.Replace(text, limit, join, this.TextLess);
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

        if (!this.TextInfra.Same(k, ka, this.TextLess))
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

    public virtual Infra Add(String a)
    {
        this.InfraInfra.AddString(this.StringAdd, a);
        return this;
    }

    public virtual Infra AddChar(long n)
    {
        this.StringAdd.Execute(n);
        return this;
    }

    public virtual Infra AddLine()
    {
        this.Add(this.TextInfra.NewLine);
        return this;
    }

    public virtual Infra AddS(string o)
    {
        return this.Add(this.S(o));
    }

    public virtual Infra AddClear()
    {
        this.StringAdd.Clear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.StringAdd.Result();
    }

    public virtual String S(string o)
    {
        return this.TextInfra.S(o);
    }
}