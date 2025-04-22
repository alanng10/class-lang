namespace Avalon.Text;

public class TextAdd : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = Infra.This;
        this.StringComp = StringComp.This;

        this.Format = this.CreateFormat();
        this.FormatArg = this.CreateFormatArg();
        this.IntParse = this.CreateIntParse();
        this.StringAdd = this.CreateStringAdd();
        this.TForm = this.CreateTextForm();
        this.TLess = this.CreateTextLess();
        this.SLess = this.CreateStringLess();
        this.ILess = this.CreateIntLess();

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

        this.TRangeA = this.CreateRange();

        this.SSpace = this.S(" ");
        this.SZero = this.S("0");
        this.SIndent = this.CreateIndent();
        return true;
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

    protected virtual StringAdd CreateStringAdd()
    {
        StringAdd a;
        a = new StringAdd();
        a.Init();
        return a;
    }

    protected virtual Form CreateTextForm()
    {
        Form a;
        a = new Form();
        a.Init();
        return a;
    }

    protected virtual Less CreateTextLess()
    {
        Less a;
        a = new Less();
        a.LiteForm = this.TForm;
        a.RiteForm = this.TForm;
        a.CharLess = this.ILess;
        a.Init();
        return a;
    }

    protected virtual StringLess CreateStringLess()
    {
        StringLess a;
        a = new StringLess();
        a.LiteForm = this.TForm;
        a.RiteForm = this.TForm;
        a.CharLess = this.ILess;
        a.Init();
        return a;
    }

    protected virtual LessInt CreateIntLess()
    {
        LessInt a;
        a = new LessInt();
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

    protected virtual Range CreateRange()
    {
        Range a;
        a = new Range();
        a.Init();
        return a;
    }

    protected virtual String CreateIndent()
    {
        return this.StringComp.CreateChar(this.Char(this.SSpace), 4);
    }

    protected virtual Infra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual Format Format { get; set; }
    protected virtual FormatArg FormatArg { get; set; }
    protected virtual IntParse IntParse { get; set; }
    protected virtual StringAdd StringAdd { get; set; }
    protected virtual Form TForm { get; set; }
    protected virtual Less TLess { get; set; }
    protected virtual StringLess SLess { get; set; }
    protected virtual LessInt ILess { get; set; }
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
    protected virtual Range TRangeA { get; set; }
    protected virtual String SSpace { get; set; }
    protected virtual String SZero { get; set; }
    protected virtual String SIndent { get; set; }

    public virtual Text TA(String k)
    {
        return this.TextString(k, this.TextA, this.StringDataA);
    }

    public virtual Text TB(String k)
    {
        return this.TextString(k, this.TextB, this.StringDataB);
    }

    public virtual Text TC(String k)
    {
        return this.TextString(k, this.TextC, this.StringDataC);
    }

    public virtual Text TD(String k)
    {
        return this.TextString(k, this.TextD, this.StringDataD);
    }

    public virtual Text TE(String k)
    {
        return this.TextString(k, this.TextE, this.StringDataE);
    }

    public virtual Text TF(String k)
    {
        return this.TextString(k, this.TextF, this.StringDataF);
    }

    public virtual Text TextString(String k, Text text, StringData data)
    {
        data.ValueString = k;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = this.StringCount(k);
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

    public virtual bool BoolText(Text text)
    {
        bool k;
        k = false;

        if (this.TextSame(text, this.TE(this.TextInfra.BoolTrueString)))
        {
            k = true;
        }
        return k;
    }

    public virtual long IntText(Text text, long varBase)
    {
        return this.IntParse.Execute(text, varBase, null);
    }

    public virtual Text TextCreate(String value)
    {
        return this.TextInfra.TextCreateStringData(value, null);
    }

    public virtual long TextIndex(Text text, Text other)
    {
        return this.TextInfra.Index(text, other, this.TLess);
    }

    public virtual long TextLastIndex(Text text, Text other)
    {
        return this.TextInfra.LastIndex(text, other, this.TLess);
    }

    public virtual bool TextStart(Text text, Text other)
    {
        return this.TextInfra.Start(text, other, this.TLess);
    }

    public virtual bool TextEnd(Text text, Text other)
    {
        return this.TextInfra.End(text, other, this.TLess);
    }

    public virtual long TextLess(Text lite, Text rite)
    {
        return this.TLess.Execute(lite, rite);
    }

    public virtual bool TextSame(Text text, Text other)
    {
        return this.TextInfra.Same(text, other, this.TLess);
    }

    public virtual Text TextForm(Text text, Form form)
    {
        long count;
        count = text.Range.Count;

        Text a;
        a = this.TextInfra.TextCreate(count);

        this.TextInfra.Form(a, text, form);

        return a;
    }

    public virtual Text TextAlphaNite(Text text)
    {
        return this.TextForm(text, this.TextInfra.AlphaNiteForm);
    }

    public virtual Text TextAlphaSite(Text text)
    {
        return this.TextForm(text, this.TextInfra.AlphaSiteForm);
    }

    public virtual Array TextLimit(Text text, Text limit)
    {
        return this.TextInfra.Limit(text, limit, this.TLess);
    }

    public virtual Text TextPlace(Text text, Text limit, Text join)
    {
        return this.TextInfra.Place(text, limit, join, this.TLess);
    }

    public virtual Array TextLine(Text text)
    {
        Array a;
        a = this.TextLimit(text, this.TE(this.TextInfra.NewLine));
        return a;
    }

    public virtual Text TextTrimStart(Text text)
    {
        Text space;
        space = this.TE(this.SSpace);

        long start;
        long count;
        start = text.Range.Index;
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
        long count;
        start = text.Range.Index;
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
            index = (count - 1) - i;

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

    public virtual String StringCreate(Text text)
    {
        return this.TextInfra.StringCreate(text);
    }

    public virtual String StringCreateRange(String value, long index, long count)
    {
        this.TRangeA.Index = index;
        this.TRangeA.Count = count;

        return this.StringComp.CreateString(value, this.TRangeA);
    }

    public virtual String StringCreateIndex(String value, long index)
    {
        long count;
        count = this.StringCount(value) - index;

        return this.StringCreateRange(value, index, count);
    }

    public virtual String StringCreateTextRange(Text value, long index, long count)
    {
        long ka;
        long kb;
        ka = value.Range.Index;
        kb = value.Range.Count;

        value.Range.Index = index;
        value.Range.Count = count;

        String a;
        a = this.StringCreate(value);

        value.Range.Index = ka;
        value.Range.Count = kb;

        return a;
    }

    public virtual String StringCreateTextIndex(Text value, long index)
    {
        long ka;
        long kb;
        ka = value.Range.Index;
        kb = value.Range.Count;

        value.Range.Index = index;
        value.Range.Count = (ka + kb) - index;

        String a;
        a = this.StringCreate(value);

        value.Range.Index = ka;
        value.Range.Count = kb;

        return a;
    }

    public virtual long StringCount(String value)
    {
        return this.StringComp.Count(value);
    }

    public virtual long StringChar(String value, long index)
    {
        return this.StringComp.Char(value, index);
    }

    public virtual long StringLess(String lite, String rite)
    {
        return this.SLess.Execute(lite, rite);
    }

    public virtual String StringBool(bool value)
    {
        String a;
        a = null;

        if (value)
        {
            a = this.TextInfra.BoolTrueString;
        }
        if (!value)
        {
            a = this.TextInfra.BoolFalseString;
        }
        return a;
    }

    public virtual String StringBoolFormat(bool value, bool alignLeft, long fieldWidth, long maxWidth, long fillChar)
    {
        FormatArg arg;
        arg = this.FormatArg;

        arg.Kind = 0;
        arg.Value.Bool = value;
        arg.Base = 0;
        arg.AlignLeft = alignLeft;
        arg.FieldWidth = fieldWidth;
        arg.MaxWidth = maxWidth;
        arg.FillChar = fillChar;
        arg.Form = null;

        return this.StringFormat();
    }

    public virtual String StringInt(long value)
    {
        return this.StringIntFormat(value, 10, false, 0, -1, 0);
    }

    public virtual String StringIntHex(long value)
    {
        return this.StringIntFormat(value, 16, false, 15, 15, this.Char(this.SZero));
    }

    public virtual String StringIntFormat(long value, long varBase, bool alignLeft, long fieldWidth, long maxWidth, long fillChar)
    {
        FormatArg arg;
        arg = this.FormatArg;

        arg.Kind = 1;
        arg.Value.Int = value;
        arg.Base = varBase;
        arg.AlignLeft = alignLeft;
        arg.FieldWidth = fieldWidth;
        arg.MaxWidth = maxWidth;
        arg.FillChar = fillChar;
        arg.Form = null;

        return this.StringFormat();
    }

    public virtual String StringTextFormat(Text value, bool alignLeft, long fieldWidth, long maxWidth, long fillChar)
    {
        FormatArg arg;
        arg = this.FormatArg;

        arg.Kind = 2;
        arg.Value.Any = value;
        arg.Base = 0;
        arg.AlignLeft = alignLeft;
        arg.FieldWidth = fieldWidth;
        arg.MaxWidth = maxWidth;
        arg.FillChar = fillChar;
        arg.Form = null;

        return this.StringFormat();
    }

    public virtual String StringFormat()
    {
        bool b;

        b = this.Format.ExecuteArgCount(this.FormatArg);

        if (!b)
        {
            return null;
        }

        Text k;
        k = this.TextInfra.TextCreate(this.FormatArg.Count);

        b = this.Format.ExecuteArgResult(this.FormatArg, k);

        if (!b)
        {
            return null;
        }

        String a;
        a = this.StringCreate(k);

        return a;
    }

    public virtual long Char(String value)
    {
        return this.TextInfra.Char(value);
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

    public virtual TextAdd AddBool(bool value)
    {
        return this.Add(this.StringBool(value));
    }

    public virtual TextAdd AddBoolFormat(bool value, bool alignLeft, long fieldWidth, long maxWidth, long fillChar)
    {
        return this.Add(this.StringBoolFormat(value, alignLeft, fieldWidth, maxWidth, fillChar));
    }

    public virtual TextAdd AddInt(long value)
    {
        return this.Add(this.StringInt(value));
    }

    public virtual TextAdd AddIntHex(long value)
    {
        return this.Add(this.StringIntHex(value));
    }

    public virtual TextAdd AddIntFormat(long value, long varBase, bool alignLeft, long fieldWidth, long maxWidth, long fillChar)
    {
        return this.Add(this.StringIntFormat(value, varBase, alignLeft, fieldWidth, maxWidth, fillChar));
    }

    public virtual TextAdd AddText(Text value)
    {
        return this.Add(this.StringCreate(value));
    }

    public virtual TextAdd AddTextFormat(Text value, bool alignLeft, long fieldWidth, long maxWidth, long fillChar)
    {
        return this.Add(this.StringTextFormat(value, alignLeft, fieldWidth, maxWidth, fillChar));
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

    public virtual String S(string o)
    {
        return this.TextInfra.S(o);
    }
}