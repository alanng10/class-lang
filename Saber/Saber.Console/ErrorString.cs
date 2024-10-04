namespace Saber.Console;

public class ErrorString : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.BorderLine = this.StringComp.CreateChar('-', 50);
        this.SKind = this.S("Kind");
        this.SName = this.S("Name");
        this.SRange = this.S("Range");
        this.SSource = this.S("Source");
        this.SSpace = this.S(" ");
        this.SComma = this.S(",");
        this.SColon = this.S(":");
        this.SBraceRoundLite = this.S("(");
        this.SBraceRoundRite = this.S(")");
        return true;
    }

    protected virtual String BorderLine { get; set; }
    protected virtual String SKind { get; set; }
    protected virtual String SName { get; set; }
    protected virtual String SRange { get; set; }
    protected virtual String SSource { get; set; }
    protected virtual String SSpace { get; set; }
    protected virtual String SComma { get; set; }
    protected virtual String SColon { get; set; }
    protected virtual String SBraceRoundLite { get; set; }
    protected virtual String SBraceRoundRite { get; set; }

    public virtual String Execute(Error error)
    {
        this.AddClear();

        this.AddBorder();

        this.AddField(this.SKind, this.KindString(error));

        bool b;
        b = (error.Source == null);

        if (b)
        {
            String kk;
            kk = error.Name;
            
            if (!(kk == null))
            {
                this.AddField(this.SName, kk);
            }
        }
        if (!b)
        {
            this.AddField(this.SRange, this.RangeString(error));

            this.AddField(this.SSource, this.SourceString(error));
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

    protected virtual bool AddField(String word, String value)
    {
        this.Add(word).Add(this.SColon).Add(this.SSpace).Add(value).AddLine();
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
        ka = this.StringInt(range.Start);

        String kb;
        kb = this.StringInt(range.End);

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