namespace Class.Infra;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.StringComp = StringComp.This;
        this.TextStringValue = StringValue.This;

        this.StringAdd = new StringAdd();
        this.StringAdd.Init();

        this.CharLess = new LessInt();
        this.CharLess.Init();
        this.CharForm = new CharForm();
        this.CharForm.Init();
        this.TextLess = new TextLess();
        this.TextLess.CharLess = this.CharLess;
        this.TextLess.LiteCharForm = this.CharForm;
        this.TextLess.RiteCharForm = this.CharForm;
        this.TextLess.Init();

        this.Range = new InfraRange();
        this.Range.Init();

        this.TextA = this.CreateText();
        this.TextB = this.CreateText();
        this.TextC = this.CreateText();
        this.TextD = this.CreateText();

        this.StringDataA = new StringData();
        this.StringDataA.Init();
        this.StringDataB = new StringData();
        this.StringDataB.Init();
        this.StringDataC = new StringData();
        this.StringDataC.Init();
        this.StringDataD = new StringData();
        this.StringDataD.Init();

        this.Write = new Write();
        this.Write.Init();
        this.Write.CharForm = this.CharForm;

        WriteArg arg;
        arg = new WriteArg();
        arg.Init();
        arg.Kind = 1;
        arg.Base = 10;
        arg.Case = 0;
        arg.AlignLeft = false;
        arg.FieldWidth = 1;
        arg.MaxWidth = -1;
        this.WriteArgInt = arg;

        arg = new WriteArg();
        arg.Init();
        arg.Kind = 1;
        arg.Base = 16;
        arg.Case = 0;
        arg.AlignLeft = false;
        arg.FieldWidth = 15;
        arg.MaxWidth = 15;
        arg.FillChar = '0';
        this.WriteArgIntHex = arg;

        this.Indent = this.StringComp.CreateChar(' ', 4);
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual StringValue TextStringValue { get; set; }
    protected virtual StringAdd StringAdd { get; set; }
    protected virtual TextLess TextLess { get; set; }
    protected virtual LessInt CharLess { get; set; }
    protected virtual CharForm CharForm { get; set; }
    protected virtual InfraRange Range { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual Text TextB { get; set; }
    protected virtual Text TextC { get; set; }
    protected virtual Text TextD { get; set; }
    protected virtual StringData StringDataA { get; set; }
    protected virtual StringData StringDataB { get; set; }
    protected virtual StringData StringDataC { get; set; }
    protected virtual StringData StringDataD { get; set; }
    protected virtual Write Write { get; set; }
    protected virtual WriteArg WriteArgInt { get; set; }
    protected virtual WriteArg WriteArgIntHex { get; set; }
    protected virtual String Indent { get; set; }

    protected virtual Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new InfraRange();
        a.Range.Init();
        return a;
    }

    public virtual bool TextStringGet(Text text, StringData data, String o)
    {
        data.ValueString = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = this.StringCount(o);
        return true;
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

    public virtual Text Replace(Text text, string limit, String join)
    {
        return this.TextReplace(text, this.TextCreate(this.S(limit)), this.TextCreate(join));
    }

    public virtual String StringCreate(Text text)
    {
        return this.TextInfra.StringCreate(text);
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

    public virtual Text TextCreate(String o)
    {
        return this.TextInfra.TextCreateStringData(o, null);
    }

    public virtual Text TextReplace(Text text, Text limit, Text join)
    {
        return this.TextInfra.Replace(text, limit, join, this.TextLess);
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

    public virtual Gen AddIndent(long indent)
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

    public virtual Gen Add(String a)
    {
        this.InfraInfra.AddString(this.StringAdd, a);
        return this;
    }

    public virtual Gen AddChar(long n)
    {
        this.StringAdd.Execute(n);
        return this;
    }

    public virtual Gen AddLine()
    {
        this.Add(this.TextInfra.NewLine);
        return this;
    }

    public virtual Gen AddS(string o)
    {
        return this.Add(this.S(o));
    }

    public virtual Gen AddClear()
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
        return this.TextStringValue.Execute(o);
    }
}