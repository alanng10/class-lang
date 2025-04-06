namespace Saber.Infra;

public class TextAdd : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.StringComp = StringComp.This;

        this.StringAdd = this.CreateStringAdd();

        this.Format = this.CreateFormat();
        this.FormatArg = this.CreateFormatArg();

        this.IntParse = this.CreateIntParse();

        this.CharLess = this.CreateCharLess();
        this.TForm = this.CreateTextForm();
        this.TLess = this.CreateTextLess();

        this.TextA = this.CreateText();
        this.TextB = this.CreateText();
        this.TextC = this.CreateText();
        this.TextD = this.CreateText();
        this.TextE = this.CreateText();
        this.TextF = this.CreateText();

        this.StringDataA = this.CreateStringData();
        this.StringDataB = this.CreateStringData();
        this.StringDataC = this.CreateStringData();
        this.StringDataD = this.CreateStringData();
        this.StringDataE = this.CreateStringData();
        this.StringDataF = this.CreateStringData();

        this.RangeA = this.CreateRange();

        this.SIndent = this.CreateIndent();

        this.SSpace = this.S(" ");
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual Format Format { get; set; }
    protected virtual FormatArg FormatArg { get; set; }
    protected virtual StringAdd StringAdd { get; set; }
    protected virtual IntParse IntParse { get; set; }
    protected virtual TextLess TLess { get; set; }
    protected virtual LessInt CharLess { get; set; }
    protected virtual TextForm TForm { get; set; }
    protected virtual InfraRange RangeA { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual Text TextB { get; set; }
    protected virtual Text TextC { get; set; }
    protected virtual Text TextD { get; set; }
    protected virtual Text TextE { get; set; }
    protected virtual Text TextF { get; set; }
    protected virtual StringData StringDataA { get; set; }
    protected virtual StringData StringDataB { get; set; }
    protected virtual StringData StringDataC { get; set; }
    protected virtual StringData StringDataD { get; set; }
    protected virtual StringData StringDataE { get; set; }
    protected virtual StringData StringDataF { get; set; }
    protected virtual String SIndent { get; set; }
    protected virtual String SSpace { get; set; }

    protected virtual StringAdd CreateStringAdd()
    {
        StringAdd a;
        a = new StringAdd();
        a.Init();
        return a;
    }

    protected virtual Format CreateFormat()
    {
        Format a;
        a = new Format();
        a.Init();
        return a;
    }

    protected virtual FormatArg CreateFormatArg()
    {
        FormatArg a;
        a = new FormatArg();
        a.Init();
        return a;
    }

    protected virtual IntParse CreateIntParse()
    {
        IntParse a;
        a = new IntParse();
        a.Init();
        return a;
    }

    protected virtual LessInt CreateCharLess()
    {
        LessInt a;
        a = new LessInt();
        a.Init();
        return a;
    }

    protected virtual TextForm CreateTextForm()
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
        a.LiteForm = this.TForm;
        a.RiteForm = this.TForm;
        a.Init();
        return a;
    }

    protected virtual Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new InfraRange();
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

    protected virtual InfraRange CreateRange()
    {
        InfraRange a;
        a = new InfraRange();
        a.Init();
        return a;
    }

    protected virtual String CreateIndent()
    {
        return this.StringComp.CreateChar(' ', 4);
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

    public virtual Text TE(String o)
    {
        return this.TextString(o, this.TextE, this.StringDataE);
    }

    public virtual Text TF(String o)
    {
        return this.TextString(o, this.TextF, this.StringDataF);
    }

    public virtual Text TextString(String o, Text text, StringData data)
    {
        data.ValueString = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = this.StringCount(o);
        return text;
    }

    public virtual bool ClearText(Text text)
    {
        text.Data = null;
        return true;
    }

    public virtual bool ClearStringData(StringData stringData)
    {
        stringData.ValueString = null;
        return true;
    }

    public virtual bool ClearData()
    {
        this.ClearText(this.TextA);
        this.ClearText(this.TextB);
        this.ClearText(this.TextC);
        this.ClearText(this.TextD);
        this.ClearText(this.TextE);
        this.ClearText(this.TextF);

        this.ClearStringData(this.StringDataA);
        this.ClearStringData(this.StringDataB);
        this.ClearStringData(this.StringDataC);
        this.ClearStringData(this.StringDataD);
        this.ClearStringData(this.StringDataE);
        this.ClearStringData(this.StringDataF);
        return true;
    }

    public virtual String StringInt(long n)
    {
        return this.StringIntFormat(n, 10, false, 1, -1, 0);
    }

    public virtual String StringIntHex(long n)
    {
        return this.StringIntFormat(n, 16, false, 15, 15, '0');
    }

    public virtual String StringIntFormat(long n, long varBase, bool alignLeft, long fieldWidth, long maxWidth, long fillChar)
    {
        FormatArg arg;
        arg = this.FormatArg;

        arg.Kind = 1;
        arg.Value.Int = n;
        arg.Base = varBase;
        arg.AlignLeft = alignLeft;
        arg.FieldWidth = fieldWidth;
        arg.MaxWidth = maxWidth;
        arg.FillChar = fillChar;

        return this.StringFormat();
    }

    public virtual String StringTextFormat(Text text, bool alignLeft, long fieldWidth, long maxWidth, long fillChar)
    {
        FormatArg arg;
        arg = this.FormatArg;

        arg.Kind = 2;
        arg.Value.Any = text;
        arg.Base = 0;
        arg.AlignLeft = alignLeft;
        arg.FieldWidth = fieldWidth;
        arg.MaxWidth = maxWidth;
        arg.FillChar = fillChar;

        return this.StringFormat();
    }

    public virtual String StringFormat()
    {
        this.Format.ExecuteArgCount(this.FormatArg);

        Text aa;
        aa = this.TextInfra.TextCreate(this.FormatArg.Count);

        this.Format.ExecuteArgResult(this.FormatArg, aa);

        String a;
        a = this.StringCreate(aa);

        return a;
    }

    public virtual long IntText(Text text, long varBase)
    {
        return this.IntParse.Execute(text, varBase, null);
    }

    public virtual Text Place(Text text, string limit, String join)
    {
        return this.TextPlace(text, this.TE(this.S(limit)), this.TF(join));
    }

    public virtual Text TextAlphaNite(Text text)
    {
        return this.TextForm(text, this.TextInfra.AlphaNiteForm);
    }

    public virtual Text TextAlphaSite(Text text)
    {
        return this.TextForm(text, this.TextInfra.AlphaSiteForm);
    }

    public virtual Text TextForm(Text text, TextForm form)
    {
        long count;
        count = text.Range.Count;

        Text a;
        a = this.TextInfra.TextCreate(count);

        this.TextInfra.Form(a, text, form);

        return a;
    }

    public virtual String StringCreate(Text text)
    {
        return this.TextInfra.StringCreate(text);
    }

    public virtual Text TextCreate(String o)
    {
        return this.TextInfra.TextCreateStringData(o, null);
    }

    public virtual bool TextStart(Text text, Text other)
    {
        return this.TextInfra.Start(text, other, this.TLess);
    }

    public virtual bool TextEnd(Text text, Text other)
    {
        return this.TextInfra.End(text, other, this.TLess);
    }

    public virtual bool TextSame(Text text, Text other)
    {
        return this.TextInfra.Same(text, other, this.TLess);
    }

    public virtual long TextLess(Text lite, Text rite)
    {
        return this.TLess.Execute(lite, rite);
    }

    public virtual long TextIndex(Text text, Text other)
    {
        return this.TextInfra.Index(text, other, this.TLess);
    }

    public virtual long TextLastIndex(Text text, Text other)
    {
        return this.TextInfra.LastIndex(text, other, this.TLess);
    }

    public virtual Text TextTrimStart(Text text)
    {
        Text space;
        space = this.TE(this.SSpace);

        long start;
        start = text.Range.Index;

        long count;
        count = text.Range.Count;

        long k;
        k = 0;

        text.Range.Count = 1;

        bool b;
        b = false;

        long i;
        i = 0;
        while (!b & i < count)
        {
            text.Range.Index = start + i;

            if (!this.TextSame(text, space))
            {
                k = i;
                b = true;
            }

            i = i + 1;
        }

        if (!b)
        {
            k = count;
        }

        text.Range.Index = start + k;
        text.Range.Count = count - k;

        return text;
    }

    public virtual Text TextTrimEnd(Text text)
    {
        Text space;
        space = this.TE(this.SSpace);

        long start;
        start = text.Range.Index;

        long count;
        count = text.Range.Count;

        long k;
        k = count;

        text.Range.Count = 1;

        bool b;
        b = false;

        long i;
        i = 0;
        while (!b & i < count)
        {
            long index;
            index = count - 1 - i;

            text.Range.Index = start + index;

            if (!this.TextSame(text, space))
            {
                k = index + 1;
                b = true;
            }

            i = i + 1;
        }

        if (!b)
        {
            k = 0;
        }

        text.Range.Index = start;
        text.Range.Count = k;

        return text;
    }

    public virtual Array TextLimit(Text text, Text limit)
    {
        return this.TextInfra.Limit(text, limit, this.TLess);
    }

    public virtual Text TextPlace(Text text, Text limit, Text join)
    {
        return this.TextInfra.Place(text, limit, join, this.TLess);
    }

    public virtual long StringCount(String o)
    {
        return this.StringComp.Count(o);
    }

    public virtual long StringChar(String o, long index)
    {
        return this.StringComp.Char(o, index);
    }

    public virtual String StringCreateRange(String o, long index, long count)
    {
        this.RangeA.Index = index;
        this.RangeA.Count = count;

        return this.StringComp.CreateString(o, this.RangeA);
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

    public virtual long Char(String value)
    {
        return this.TextInfra.Char(value);
    }

    public virtual TextAdd AddIndent(long indent)
    {
        long count;
        count = indent;
        long i;
        i = 0;
        while (i < count)
        {
            this.Add(this.SIndent);
            i = i + 1;
        }
        return this;
    }

    public virtual TextAdd Add(String a)
    {
        this.TextInfra.AddString(this.StringAdd, a);
        return this;
    }

    public virtual TextAdd AddChar(long n)
    {
        this.StringAdd.Execute(n);
        return this;
    }

    public virtual TextAdd AddLine()
    {
        this.Add(this.TextInfra.NewLine);
        return this;
    }

    public virtual TextAdd AddS(string o)
    {
        return this.Add(this.S(o));
    }

    public virtual TextAdd AddClear()
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