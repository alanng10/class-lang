namespace Class.Console;

public class ErrorString : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.NewLine = this.InfraInfra.NewLine;

        this.Format = new Format();
        this.Format.Init();
        this.FormatArg = new FormatArg();
        this.FormatArg.Init();

        this.BorderLine = "--------------------------------------------------";
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Format Format { get; set; }
    protected virtual FormatArg FormatArg { get; set; }
    protected virtual string NewLine { get; set; }
    protected virtual string BorderLine { get; set; }

    public virtual string String(Error error)
    {
        StringJoin h;
        h = new StringJoin();
        h.Init();


        this.AppendBorder(h);

        this.AppendField(h, "Kind", this.KindString(error));

        this.AppendField(h, "Range", this.RangeString(error));
            
        this.AppendField(h, "Source", this.SourceString(error));

        this.AppendBorder(h);

        string a;
        a = h.Result();

        return a;
    }

    protected virtual bool AppendBorder(StringJoin sb)
    {
        sb.Append(this.BorderLine);
        sb.Append(this.NewLine);
        return true;
    }

    protected virtual bool AppendField(StringJoin sb, string word, string value)
    {
        sb.Append(word);
        sb.Append(":");
        sb.Append(" ");
        sb.Append(value);
        sb.Append(this.NewLine);
        return true;
    }

    protected virtual string KindString(Error error)
    {
        ErrorKind errorKind;
        errorKind = error.Kind;
                
        string a;
        a = errorKind.Text;

        return a;
    }

    protected virtual string RangeString(Error error)
    {
        string s;



        s = this.TokenRangeString(error);
        
        


        string ret;



        ret = s;


        return ret;
    }

    protected virtual string TokenRangeString(Error error)
    {
        Range range;
        range = error.Range;

        StringJoin sb;
        sb = new StringJoin();
        sb.Init();

        string ka;
        ka = this.IntString(range.Start);

        string kb;
        kb = this.IntString(range.End);

        sb.Append("(");
        sb.Append(ka);
        sb.Append(",");
        sb.Append(" ");
        sb.Append(kb);
        sb.Append(")");

        string a;
        a = sb.Result();

        return a;
    }

    protected virtual string SourceString(Error error)
    {
        Source aa;
        aa = error.Source;

        string a;
        a = aa.Name;
        return a;
    }

    protected virtual string IntString(int value)
    {
        FormatArg e;
        e = this.FormatArg;

        e.Kind = 1;
        e.Base = 10;
        e.Case = 0;
        e.AlignLeft = false;
        e.FieldWidth = 0;
        e.MaxWidth = -1;
        e.ValueInt = value;

        this.Format.ExecuteArgCount(e);

        Text text;
        text = this.TextInfra.TextCreate(e.Count);

        this.Format.ExecuteArgResult(e, text);

        string a;
        a = this.TextInfra.StringCreate(text);
        return a;
    }
}