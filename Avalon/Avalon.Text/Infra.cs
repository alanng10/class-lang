namespace Avalon.Text;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.IntHexFormat = "x15";
        this.IntHexDigitCount = 15;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    private string IntHexFormat { get; set; }

    public virtual int IntHexDigitCount { get; set; }

    public virtual bool IsDigit(char o)
    {
        return !((o < '0') | ('9' < o));
    }

    public virtual bool IsHexLetter(char o)
    {
        return !((o < 'a') | ('f' < o));
    }

    public virtual bool IsLowerLetter(char o)
    {
        return !((o < 'a') | ('z' < o));
    }

    public virtual bool IsUpperLetter(char o)
    {
        return !((o < 'A') | ('Z' < o));
    }

    public virtual char GetChar(Text text, Pos pos)
    {
        char oc;        
        oc = text.GetLine(pos.Row).Value[pos.Col];
        return oc;
    }

    public virtual bool Equal(Text text, Range range, string o)
    {
        Line line;
        line = text.GetLine(range.Row);

        int k;
        k = this.InfraInfra.Count(range.Col);
        int count;
        count = k;
        if (!(count == o.Length))
        {
            return false;
        }

        int index;
        char oca;
        char ocb;
        int i;
        i = 0;
        while (i < count)
        {
            index = range.Col.Start + i;

            oca = line.Value[index];
            ocb = o[i];
            if (!(oca == ocb))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    public virtual Span SpanCreate(int count)
    {
        Span span;
        span = new Span();
        span.Init();
        span.Data = new char[count];
        span.Range = new InfraRange();
        span.Range.Init();
        span.Range.End = count;
        return span;
    }

    public virtual Span SpanCreateString(string a)
    {
        Span span;
        span = new Span();
        span.Init();
        span.Data = a.ToCharArray();
        span.Range = new InfraRange();
        span.Range.Init();
        span.Range.End = span.Data.Length;
        return span;
    }

    public virtual string StringCreate(Span o)
    {
        InfraRange range;
        range = o.Range;
        int count;
        count = this.InfraInfra.Count(range);
        string a;
        a = new string(o.Data, range.Start, count);
        return a;
    }

    public virtual bool GetIntHexText(Span span, long n)
    {
        ulong kk;
        kk = (ulong)n;
    
        int count;
        count = this.InfraInfra.Count(span.Range);

        SpanChar spanU;
        spanU = new SpanChar(span.Data, span.Range.Start, count);

        ReadOnlySpanChar formatSpan;
        formatSpan = MemoryExtensions.AsSpan(this.IntHexFormat);
        
        int outU;

        bool b;
        b = kk.TryFormat(spanU, out outU, formatSpan, CultureInfo.InvariantCulture);
        if (!b)
        {
            return false;
        }
        return true;
    }

    public virtual long GetIntHex(Span span)
    {
        int count;
        count = this.InfraInfra.Count(span.Range);
        if (15 < count)
        {
            return -1;
        }

        ReadOnlySpanChar spanU;
        spanU = new ReadOnlySpanChar(span.Data, span.Range.Start, count);

        ulong o;
        bool b;
        b = ulong.TryParse(spanU, NumberStyle.AllowHexSpecifier, CultureInfo.InvariantCulture, out o);
        if (!b)
        {
            return -1;
        }

        long k;
        k = (long)o;
        if (k < 0)
        {
            return -1;
        }

        if (!(k < this.InfraInfra.IntCapValue))
        {
            return -1;
        }
        return k;
    }

    public virtual long GetInt(Span span)
    {
        int count;
        count = this.InfraInfra.Count(span.Range);

        ReadOnlySpanChar spanU;
        spanU = new ReadOnlySpanChar(span.Data, span.Range.Start, count);

        ulong o;
        bool b;
        b = ulong.TryParse(spanU, NumberStyle.None, CultureInfo.InvariantCulture, out o);
        if (!b)
        {
            return -1;
        }

        long k;
        k = (long)o;
        if (k < 0)
        {
            return -1;
        }

        if (!(k < this.InfraInfra.IntCapValue))
        {
            return -1;
        }

        long a;
        a = k;
        return a;
    }






    public virtual int GetIndex(Span span, char oc)
    {
        InfraRange range;

        range = span.Range;



        int count;

        count = this.InfraInfra.Count(range);




        return SystemArray.IndexOf<char>(span.Data, oc, range.Start, count);
    }
}