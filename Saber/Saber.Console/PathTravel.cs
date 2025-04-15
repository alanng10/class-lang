namespace Saber.Console;

public partial class PathTravel : Travel
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.TextBraceRightLite = this.S("[");
        this.TextBraceRightRite = this.S("]");

        this.InitString();
        return true;
    }

    public virtual NodeNode Result { get; set; }
    public virtual Text Path { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual InfraRange Field { get; set; }
    protected virtual InfraRange FieldName { get; set; }
    protected virtual long Index { get; set; }
    protected virtual long ThisIndex { get; set; }
    protected virtual String TextBraceRightLite { get; set; }
    protected virtual String TextBraceRightRite { get; set; }

    protected override bool ExecuteNode(NodeNode node)
    {
        if (!(this.ThisIndex < this.Path.Range.Count))
        {
            this.Result = node;
            return true;
        }

        this.SetField();

        this.SetFieldNameIndex();

        this.ThisIndex = this.ThisIndex + this.FieldName.Count + 1;
        return true;
    }

    protected virtual bool SetField()
    {
        long start;
        start = this.ThisIndex;

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
        u = this.TextIndex(path, this.TA(this.ClassInfra.TextDot));

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
        this.TextA.Data = this.Path.Data;
        this.TextA.Range.Index = this.Path.Range.Index + this.Field.Index;
        this.TextA.Range.Count = this.Field.Count;

        long ka;
        ka = this.BraceRightLiteIndex(this.TextA);

        bool b;
        b = (ka < 0);

        if (!b)
        {
            long braceRightLite;
            braceRightLite = ka;

            this.Index = this.FieldIndex(this.Field, braceRightLite);

            this.FieldName.Index = this.Field.Index;
            this.FieldName.Count = braceRightLite;
        }

        if (b)
        {
            this.Index = -1;

            this.FieldName.Index = this.Field.Index;
            this.FieldName.Count = this.Field.Count;
        }
        return true;
    }

    protected virtual long BraceRightLiteIndex(Text text)
    {
        long a;
        a = this.TextIndex(text, this.TA(this.TextBraceRightLite));
        return a;
    }

    protected virtual long FieldIndex(InfraRange varField, long braceRightLite)
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
        b = this.TextEnd(textA, this.TA(this.TextBraceRightRite));

        if (!b)
        {
            return -1;
        }

        long start;
        start = braceRightLite + this.StringCount(this.TextBraceRightLite);

        long end;
        end = varField.Count - this.StringCount(this.TextBraceRightRite);

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
        this.TextA.Data = this.Path.Data;

        this.TextA.Range.Index = this.Path.Range.Index + this.FieldName.Index;
        this.TextA.Range.Count = this.FieldName.Count;

        bool a;
        a = this.TextSame(this.TextA, this.TB(name));
        return a;
    }
}