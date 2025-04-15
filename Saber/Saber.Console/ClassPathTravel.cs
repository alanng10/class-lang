namespace Saber.Console;

public partial class PathTravel : Travel
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;

        this.TextBraceRightLite = this.S("[");
        this.TextBraceRightRite = this.S("]");

        this.InitString();
        return true;
    }

    public virtual NodeNode Result { get; set; }
    public virtual Text Path { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    protected virtual InfraRange Field { get; set; }
    protected virtual InfraRange FieldName { get; set; }
    protected virtual long Index { get; set; }
    protected virtual long CurrentIndex { get; set; }
    protected virtual String TextBraceRightLite { get; set; }
    protected virtual String TextBraceRightRite { get; set; }

    protected override bool ExecuteNode(NodeNode node)
    {
        if (!(this.CurrentIndex < this.Path.Range.Count))
        {
            this.Result = node;
            return true;
        }

        this.SetField();

        this.SetFieldNameIndex();

        this.CurrentIndex = this.CurrentIndex + this.FieldName.Count + 1;
        return true;
    }

    protected virtual bool SetField()
    {
        long start;
        start = this.CurrentIndex;

        long end;
        end = 0;

        Text path;
        path = this.Path;

        InfraRange range;
        range = path.Range;

        long ka;
        long kb;
        ka = range.Index;
        kb = range.Count;

        range.Index = ka + start;
        range.Count = kb - start;

        long u;
        u = this.TextInfra.Index(path, this.Dot, this.TextLess);

        bool b;
        b = (u < 0);
        if (b)
        {
            end = kb;
        }
        if (!b)
        {
            end = start + u;
        }

        long count;
        count = end - start;

        range.Index = ka;
        range.Count = kb;

        InfraRange a;
        a = this.Field;
        a.Index = start;
        a.Count = count;
        return true;
    }

    protected virtual bool SetFieldNameIndex()
    {
        Text path;
        path = this.Path;
        InfraRange range;
        range = path.Range;

        InfraRange field;
        field = this.Field;

        InfraRange fieldName;
        fieldName = this.FieldName;

        Text textA;
        textA = this.TextA;
        textA.Data = path.Data;
        InfraRange rangeA;
        rangeA = textA.Range;
        rangeA.Index = range.Index + field.Index;
        rangeA.Count = field.Count;

        long u;
        u = this.LeftSquareIndex(textA);

        bool b;
        b = (u < 0);

        if (!b)
        {
            long leftSquareIndex;
            leftSquareIndex = u;

            this.Index = this.GetIndex(this.Field, leftSquareIndex);

            fieldName.Index = field.Index;
            fieldName.Count = leftSquareIndex;
        }

        if (b)
        {
            this.Index = -1;

            fieldName.Index = field.Index;
            fieldName.Count = field.Count;
        }
        return true;
    }

    protected virtual long LeftSquareIndex(Text text)
    {
        long a;
        a = this.TextInfra.Index(text, this.LeftSquare, this.TextLess);
        return a;
    }

    protected virtual long GetIndex(InfraRange varField, long leftSquareIndex)
    {
        if (varField.Count < 1)
        {
            return -1;
        }

        Text path;
        path = this.Path;

        InfraRange range;
        range = path.Range;

        Text textA;
        textA = this.TextA;

        textA.Data = path.Data;
        
        InfraRange rangeA;
        rangeA = textA.Range;

        rangeA.Index = range.Index + varField.Index;
        rangeA.Count = varField.Count;

        bool b;
        b = this.TextInfra.End(textA, this.RightSquare, this.TextLess);

        if (!b)
        {
            return -1;
        }

        long start;
        start = leftSquareIndex + this.LeftSquare.Range.Count;

        long end;
        end = varField.Count - this.RightSquare.Range.Count;

        long count;
        count = end - start;

        rangeA.Index = rangeA.Index + start;
        rangeA.Count = count;

        long n;
        n = this.IntParse.Execute(textA, 10, null);

        if (n == -1)
        {
            return -1;
        }

        long a;
        a = n;
        return a;
    }

    protected virtual bool HasResult()
    {
        return !(this.Result == null);
    }

    protected virtual bool FieldEqual(String name)
    {
        Text path;
        path = this.Path;

        Text textA;
        Text textB;
        textA = this.TextA;
        textB = this.TextB;

        InfraRange fieldName;
        fieldName = this.FieldName;

        textA.Data = path.Data;
        
        InfraRange ka;
        ka = textA.Range;
        ka.Index = path.Range.Index + fieldName.Index;
        ka.Count = fieldName.Count;

        this.TextStringGet(textB, this.StringDataB, name);

        bool a;
        a = this.TextInfra.Same(textA, textB, this.TextLess);
        return a;
    }

    protected virtual bool TextStringGet(Text text, StringData data, String o)
    {
        data.ValueString = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = this.StringComp.Count(o);
        return true;
    }

    private String S(string o)
    {
        return this.TextStringValue.Execute(o);
    }
}