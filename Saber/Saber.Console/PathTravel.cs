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
    public virtual long ThisIndex { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual InfraRange Field { get; set; }
    protected virtual InfraRange FieldName { get; set; }
    protected virtual long FieldIndex { get; set; }
    protected virtual String TextBraceRightLite { get; set; }
    protected virtual String TextBraceRightRite { get; set; }

    protected override bool ExecuteNode(NodeNode node)
    {
        if (!(this.ThisIndex < this.Path.Range.Count))
        {
            this.Result = node;
            return true;
        }

        this.FieldSet();

        this.FieldNameIndexSet();

        this.ThisIndex = this.ThisIndex + this.Field.Count + this.StringCount(this.ClassInfra.TextDot);
        return true;
    }

    protected virtual bool FieldSet()
    {
        long start;
        start = this.ThisIndex;

        long end;
        end = 0;

        InfraRange range;
        range = this.Path.Range;

        long ka;
        long kb;
        ka = range.Index;
        kb = range.Count;

        range.Index = ka + start;
        range.Count = kb - start;

        long kaa;
        kaa = this.TextIndex(this.Path, this.TA(this.ClassInfra.TextDot));

        bool b;
        b = (kaa == -1);
        if (b)
        {
            end = kb;
        }
        if (!b)
        {
            end = start + kaa;
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

    protected virtual bool FieldNameIndexSet()
    {
        this.TextA.Data = this.Path.Data;
        this.TextA.Range.Index = this.Path.Range.Index + this.Field.Index;
        this.TextA.Range.Count = this.Field.Count;

        long ka;
        ka = this.BraceRightLiteIndex(this.TextA);

        bool b;
        b = (ka == -1);

        if (!b)
        {
            long braceRightLite;
            braceRightLite = ka;

            this.FieldIndex = this.FieldIndexGet(this.Field, braceRightLite);

            this.FieldName.Index = this.Field.Index;
            this.FieldName.Count = braceRightLite;
        }

        if (b)
        {
            this.FieldIndex = -1;

            this.FieldName.Index = this.Field.Index;
            this.FieldName.Count = this.Field.Count;
        }
        return true;
    }

    protected virtual long BraceRightLiteIndex(Text text)
    {
        long a;
        a = this.TextIndex(text, this.TB(this.TextBraceRightLite));
        return a;
    }

    protected virtual long FieldIndexGet(InfraRange varField, long braceRightLite)
    {
        if (varField.Count < 1)
        {
            return -1;
        }

        this.TextA.Data = this.Path.Data;

        this.TextA.Range.Index = this.Path.Range.Index + varField.Index;
        this.TextA.Range.Count = varField.Count;

        bool b;
        b = this.TextEnd(this.TextA, this.TB(this.TextBraceRightRite));

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

        this.TextA.Range.Index = this.TextA.Range.Index + start;
        this.TextA.Range.Count = count;

        long n;
        n = this.IntParse.Execute(this.TextA, 10, null);

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