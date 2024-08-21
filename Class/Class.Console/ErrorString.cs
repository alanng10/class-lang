namespace Class.Console;

public class ErrorString : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.NewLine = this.InfraInfra.NewLine;

        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();

        this.Format = new Format();
        this.Format.Init();
        this.Format.CharForm = charForm;
        this.FormatArg = new FormatArg();
        this.FormatArg.Init();

        StringCreate kk;
        kk = new StringCreate();
        kk.Init();
        this.BorderLine = kk.Char('-', 50);
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Format Format { get; set; }
    protected virtual FormatArg FormatArg { get; set; }
    protected virtual string NewLine { get; set; }
    protected virtual string BorderLine { get; set; }

    public virtual string Execute(Error error)
    {
        StringJoin h;
        h = new StringJoin();
        h.Init();

        this.AppendBorder(h);

        this.AppendField(h, "Kind", this.KindString(error));

        bool b;
        b = (error.Source == null);

        if (b)
        {
            string kk;
            kk = error.Name;
            
            if (!(kk == null))
            {
                this.AppendField(h, "Name", kk);
            }
        }
        if (!b)
        {
            this.AppendField(h, "Range", this.RangeString(error));

            this.AppendField(h, "Source", this.SourceString(error));
        }

        this.AppendBorder(h);

        string a;
        a = h.Rest();

        return a;
    }

    protected virtual bool AppendBorder(StringJoin h)
    {
        this.Append(h, this.BorderLine);
        this.Append(h, this.NewLine);
        return true;
    }

    protected virtual bool AppendField(StringJoin h, string word, string value)
    {
        this.Append(h, word);
        this.Append(h, ":");
        this.Append(h, " ");
        this.Append(h, value);
        this.Append(h, this.NewLine);
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
        Range range;
        range = error.Range;

        StringJoin h;
        h = new StringJoin();
        h.Init();

        string ka;
        ka = this.IntString(range.Start);

        string kb;
        kb = this.IntString(range.End);

        this.Append(h, "(");
        this.Append(h, ka);
        this.Append(h, ",");
        this.Append(h, " ");
        this.Append(h, kb);
        this.Append(h, ")");

        string a;
        a = h.Rest();

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

    protected virtual bool Append(StringJoin h, string text)
    {
        this.InfraInfra.StringJoinString(h, text);
        return true;
    }
}