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
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }

    public virtual bool IsDigit(char o)
    {
        return !((o < '0') | ('9' < o));
    }

    public virtual bool IsHexLetter(char o)
    {
        return !((o < 'a') | ('f' < o));
    }

    public virtual bool IsLetter(char o, bool upperCase)
    {
        char first;
        first = 'a';
        char last;
        last = 'z';
        if (upperCase)
        {
            first = 'A';
            last = 'Z';
        }
        return !((o < first) | (last < o));
    }

    public virtual char TextCharGet(Text text, Pos pos)
    {
        Line line;
        line = text.GetLine(pos.Row);
        int index;
        index = pos.Col;
        if (!(index < line.Count))
        {
            return (char)0;
        }
        return this.DataCharGet(line.Data, index);
    }

    public virtual bool Equal(Text text, Range range, string o)
    {
        Line line;
        line = text.GetLine(range.Row);

        InfraRange col;
        col = range.Col;

        if (!this.InfraInfra.CheckRange(line.Count, col))
        {
            return false;
        }

        int k;
        k = col.Count;
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
            index = col.Index + i;

            oca = this.DataCharGet(line.Data, index);
            ocb = o[i];
            if (!(oca == ocb))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    public virtual char DataCharGet(Data data, int index)
    {
        return this.InfraInfra.DataCharGet(data, index * 2);
    }

    public virtual bool DataCharSet(Data data, int index, char value)
    {
        return this.InfraInfra.DataCharSet(data, index * 2, value);
    }

    public virtual Span SpanCreate(int count)
    {
        int oa;
        oa = sizeof(char);

        Span span;
        span = new Span();
        span.Init();
        span.Data = new Data();
        span.Data.Count = count * oa;
        span.Data.Init();
        span.Range = new InfraRange();
        span.Range.Init();
        span.Range.Count = count;
        return span;
    }

    public virtual Span SpanCreateString(string a)
    {
        Data data;
        data = this.InfraInfra.DataCreateString(a);

        int count;
        count = a.Length;
        Span span;
        span = new Span();
        span.Init();
        span.Data = data;
        span.Range = new InfraRange();
        span.Range.Init();
        span.Range.Count = count;
        return span;
    }

    public virtual string StringCreate(Span span)
    {
        if (!this.CheckSpan(span))
        {
            return null;
        }
        InfraRange range;
        range = span.Range;
        string a;
        a = this.InternIntern.StringCreateData(span.Data.Value, range.Index, range.Count);
        return a;
    }

    public virtual bool CheckSpan(Span span)
    {
        int arrayCount;
        arrayCount = (int)span.Data.Count;

        InfraRange range;
        range = span.Range;
        if (!this.InfraInfra.CheckRange(arrayCount, range))
        {
            return false;
        }
        return true;
    }
}