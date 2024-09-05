namespace Class.Console;

public class ErrorString : ClassInfraGen
{
    public override bool Init()
    {
        base.Init();
        this.BorderLine = this.StringComp.CreateChar('-', 50);
        this.SSpace = this.S(" ");
        this.SComma = this.S(",");
        this.SBraceRoundLite = this.S("(");
        this.SBraceRoundRite = this.S(")");
        return true;
    }

    protected virtual String BorderLine { get; set; }
    protected virtual String SSpace { get; set; }
    protected virtual String SComma { get; set; }
    protected virtual String SBraceRoundLite { get; set; }
    protected virtual String SBraceRoundRite { get; set; }

    public virtual String Execute(Error error)
    {
        this.AddBorder();

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

        this.AddBorder();

        String a;
        a = this.AddResult();

        return a;
    }

    protected virtual bool AddBorder()
    {
        this.Add(this.BorderLine).AddLine();
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

    protected virtual String KindString(Error error)
    {
        ErrorKind errorKind;
        errorKind = error.Kind;
                
        String a;
        a = errorKind.Text;

        return a;
    }

    protected virtual String RangeString(Error error)
    {
        StringAdd hh;
        hh = this.StringAdd;

        Range range;
        range = error.Range;

        StringAdd h;
        h = new StringAdd();
        h.Init();

        this.StringAdd = h;

        String ka;
        ka = this.IntString(range.Start);

        String kb;
        kb = this.IntString(range.End);

        this.AddClear();

        this.Add(this.SBraceRoundLite);
        this.Add(ka);
        this.Add(this.SComma);
        this.Add(this.SSpace);
        this.Add(kb);
        this.Add(this.SBraceRoundRite);

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

        return a;
    }

    protected virtual String SourceString(Error error)
    {
        Source aa;
        aa = error.Source;

        String a;
        a = aa.Name;
        return a;
    }
}