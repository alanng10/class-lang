namespace Z.Infra.Infra;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ToolInfra = Infra.This;
        this.StringComp = StringComp.This;
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Infra ToolInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }

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

    public virtual Text TextLower(Text text)
    {
        return this.ToolInfra.TextLower(text);
    }

    public virtual Text TextCreate(String o)
    {
        return this.ToolInfra.TextCreate(o);
    }

    public virtual String StringCreate(Text text)
    {
        return this.ToolInfra.StringCreate(text);
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

    public virtual Array TextSplitLineString(String text)
    {
        return this.ToolInfra.TextSplitLineString(text);
    }

    public virtual Array TextSplitLine(Text text)
    {
        return this.ToolInfra.TextSplitLine(text);
    }

    public virtual Array TextSplit(Text text, Text delimit)
    {
        return this.ToolInfra.TextSplit(text, delimit);
    }

    public virtual Text TextReplace(Text text, Text delimit, Text join)
    {
        return this.ToolInfra.TextReplace(text, delimit, join);
    }

    public virtual Gen Add(String a)
    {
        this.ToolInfra.Add(a);
        return this;
    }

    public virtual Gen AddS(string o)
    {
        this.ToolInfra.AddS(o);
        return this;
    }

    public virtual Gen AddClear()
    {
        this.ToolInfra.AddClear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.ToolInfra.AddResult();
    }

    public virtual Gen AddIndent(long indent)
    {
        this.ToolInfra.AddIndent(indent);
        return this;
    }

    public virtual String S(string o)
    {
        return this.ToolInfra.S(o);
    }
}