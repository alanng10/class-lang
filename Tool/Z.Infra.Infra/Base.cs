namespace Z.Infra.Infra;

public class Base : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ToolInfra = Infra.This;
        this.StringComp = StringComp.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Infra ToolInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }

    public virtual Text TA(String o)
    {
        return this.ToolInfra.TA(o);
    }

    public virtual Text TB(String o)
    {
        return this.ToolInfra.TB(o);
    }

    public virtual Text TC(String o)
    {
        return this.ToolInfra.TC(o);
    }

    public virtual Text TD(String o)
    {
        return this.ToolInfra.TD(o);
    }

    public virtual Text TextString(String o, Text text, StringData data)
    {
        return this.ToolInfra.TextString(o, text, data);
    }

    public virtual Text CreateText(Data data, long index, long count)
    {
        return this.ToolInfra.CreateText(data, index, count);
    }

    public virtual Text Replace(Text text, string delimit, String join)
    {
        return this.TextReplace(text, this.TextCreate(this.S(delimit)), this.TextCreate(join));
    }

    public virtual long StringCount(String o)
    {
        return this.ToolInfra.StringCount(o);
    }

    public virtual String StringCreateRange(String o, long index, long count)
    {
        return this.ToolInfra.StringCreateRange(o, index, count);
    }

    public virtual String StringCreateIndex(String o, long index)
    {
        return this.ToolInfra.StringCreateIndex(o, index);
    }

    public virtual String StringCreateTextRange(Text o, long index, long count)
    {
        return this.ToolInfra.StringCreateTextRange(o, index, count);
    }

    public virtual String StringCreateTextIndex(Text o, long index)
    {
        return this.ToolInfra.StringCreateTextIndex(o, index);
    }

    public virtual Text TextAlphaNite(Text text)
    {
        return this.ToolInfra.TextAlphaNite(text);
    }

    public virtual Text TextAlphaSite(Text text)
    {
        return this.ToolInfra.TextAlphaSite(text);
    }

    public virtual Text TextCreate(String o)
    {
        return this.ToolInfra.TextCreate(o);
    }

    public virtual String StringCreate(Text text)
    {
        return this.ToolInfra.StringCreate(text);
    }

    public virtual bool TextSame(Text text, Text other)
    {
        return this.ToolInfra.TextSame(text, other);
    }

    public virtual bool TextStart(Text text, Text other)
    {
        return this.ToolInfra.TextStart(text, other);
    }

    public virtual bool TextEnd(Text text, Text other)
    {
        return this.ToolInfra.TextEnd(text, other);
    }

    public virtual long TextIndex(Text text, Text other)
    {
        return this.ToolInfra.TextIndex(text, other);
    }

    public virtual Array TextLimitLineString(Text text)
    {
        return this.ToolInfra.TextLimitLineString(text);
    }

    public virtual Array TextLimitLine(Text text)
    {
        return this.ToolInfra.TextLimitLine(text);
    }

    public virtual Array TextLimit(Text text, Text limit)
    {
        return this.ToolInfra.TextLimit(text, limit);
    }

    public virtual Text TextReplace(Text text, Text limit, Text join)
    {
        return this.ToolInfra.TextReplace(text, limit, join);
    }

    public virtual Base Add(String a)
    {
        this.ToolInfra.Add(a);
        return this;
    }

    public virtual Base AddChar(long a)
    {
        this.ToolInfra.AddChar(a);
        return this;
    }

    public virtual Base AddS(string o)
    {
        this.ToolInfra.AddS(o);
        return this;
    }

    public virtual Base AddClear()
    {
        this.ToolInfra.AddClear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.ToolInfra.AddResult();
    }

    public virtual Base AddIndent(long indent)
    {
        this.ToolInfra.AddIndent(indent);
        return this;
    }

    public virtual String S(string o)
    {
        return this.ToolInfra.S(o);
    }
}