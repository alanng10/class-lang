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
        Line line;
        line = text.GetLine(pos.Row);
        int index;
        index = pos.Col;
        if (!(index < line.Count))
        {
            return (char)0;
        }
        return this.CharGet(line.Data, index);
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

            oca = this.CharGet(line.Data, index);
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
        int oa;
        oa = this.InfraInfra.ShortByteCount;

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
        data = this.DataCreateString(a);

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

    public virtual char CharGet(Data data, int index)
    {
        int oa;
        oa = this.InfraInfra.ShortByteCount;

        int oo;
        oo = index * oa;

        int oaa;
        oaa = data.Get(oo);
        int oab;
        oab = data.Get(oo + 1);
        int o;
        o = oaa;
        o = o | (oab << 8);
        short ob;
        ob = (short)o;
        char oc;
        oc = (char)ob;
        return oc;
    }

    public virtual bool CharSet(Data data, int index, char value)
    {
        int oa;
        oa = this.InfraInfra.ShortByteCount;

        int oo;
        oo = index * oa;

        int ob;
        ob = (int)value;

        int oaa;
        int oab;
        oaa = ob & 0xff;
        oab = (ob >> 8) & 0xff;

        data.Set(oo, oaa);
        data.Set(oo + 1, oab);
        return true;
    }

    public virtual Data DataCreateString(string a)
    {
        int count;
        count = a.Length;

        int oa;
        oa = this.InfraInfra.ShortByteCount;

        Data data;
        data = new Data();
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

        return data;
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

    public virtual bool GetIntHexText(Span span, long n)
    {
        if (!this.CheckSpan(span))
        {
            return false;
        }
        InfraRange range;
        range = span.Range;

        ulong kk;
        kk = (ulong)n;

        bool b;
        b = this.InternIntern.IntHexText(span.Data.Value, range.Index, range.Count, kk);
        return true;
    }

    public virtual long GetIntHex(Span span)
    {
        if (!this.CheckSpan(span))
        {
            return -1;
        }
        InfraRange range;
        range = span.Range;
        int count;
        count = range.Count;
        if (15 < count)
        {
            return -1;
        }

        long k;
        k = this.InternIntern.IntHex(span.Data.Value, range.Index, count);

        if (!(k < this.InfraInfra.IntCapValue))
        {
            return -1;
        }
        return k;
    }

    public virtual long GetInt(Span span)
    {
        if (!this.CheckSpan(span))
        {
            return -1;
        }
        InfraRange range;
        range = span.Range;
        
        long k;
        k = this.InternIntern.IntFromText(span.Data.Value, range.Index, range.Count);

        if (!(k < this.InfraInfra.IntCapValue))
        {
            return -1;
        }

        long a;
        a = k;
        return a;
    }
}