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
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;
        
        this.IntHexDigitCount = 15;
        return true;
    }

    private InternIntern InternIntern { get; set; }
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
        k = range.Col.Count;
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
            index = range.Col.Index + i;

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
        span.Data = new InfraData();
        span.Data.Count = count;
        span.Data.Init();
        span.Range = new InfraRange();
        span.Range.Init();
        span.Range.Count = count;
        return span;
    }

    public virtual Span SpanCreateString(string a)
    {
        int count;
        count = a.Length;

        int oa;
        oa = this.InfraInfra.ShortByteCount;

        InfraData data;
        data = new InfraData();
        data.Count = count * oa;
        data.Init();

        DataWrite write;
        write = new DataWrite();
        write.Init();
        write.Data = data;

        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = a[i];
            short oo;
            oo = (short)oc;
            long index;
            index = i * oa;
            
            write.ExecuteShort(index, oo);
            i = i + 1;
        }

        Span span;
        span = new Span();
        span.Init();
        span.Data = data;
        span.Range = new InfraRange();
        span.Range.Init();
        span.Range.Count = count;
        return span;
    }

    public virtual string StringCreate(Span o)
    {
        int arrayCount;
        arrayCount = (int)o.Data.Count;

        InfraRange range;
        range = o.Range;
        if (!this.InfraInfra.CheckRange(arrayCount, range))
        {
            return null;
        }
        
        string a;
        a = this.InternIntern.StringCreateData(o.Data.Value, range.Index, range.Count);
        return a;
    }

    public virtual bool GetIntHexText(Span span, long n)
    {
        int arrayCount;
        arrayCount = (int)span.Data.Count;

        InfraRange range;
        range = span.Range;
        if (!this.InfraInfra.CheckRange(arrayCount, range))
        {
            return false;
        }

        ulong kk;
        kk = (ulong)n;

        bool b;
        b = this.InternIntern.IntHexText(span.Data.Value, range.Index, range.Count, kk);
        return true;
    }

    public virtual long GetIntHex(Span span)
    {
        int count;
        count = span.Range.Count;
        if (15 < count)
        {
            return -1;
        }

        ReadOnlySpanChar spanU;
        spanU = new ReadOnlySpanChar(span.Data, span.Range.Index, count);

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
        count = span.Range.Count;

        ReadOnlySpanChar spanU;
        spanU = new ReadOnlySpanChar(span.Data.Value, span.Range.Index, count);

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
}