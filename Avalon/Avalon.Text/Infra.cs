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
        this.BoolFalseString = "false";
        this.BoolTrueString = "true";
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    public virtual string BoolFalseString { get; set; }
    public virtual string BoolTrueString { get; set; }

    public virtual bool IsDigit(char o)
    {
        return this.IsInRange('0', '9', o);
    }

    public virtual bool IsHexLetter(char o)
    {
        return this.IsInRange('a', 'f', o);
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
        return this.IsInRange(first, last, o);
    }

    public virtual bool IsInRange(char first, char last, char o)
    {
        if (last < first)
        {
            return false;
        }
        return !((o < first) | (last < o));
    }

    public virtual char DataCharGet(Data data, int index)
    {
        long n;
        n = index;
        return this.InfraInfra.DataCharGet(data, n * 2);
    }

    public virtual bool DataCharSet(Data data, int index, char value)
    {
        long n;
        n = index;
        return this.InfraInfra.DataCharSet(data, n * 2, value);
    }

    public virtual Text TextCreate(int count)
    {
        if (count < 0)
        {
            return null;
        }

        int oa;
        oa = sizeof(char);

        Text a;
        a = new Text();
        a.Init();
        a.Data = new Data();
        a.Data.Count = count * oa;
        a.Data.Init();
        a.Range = new Range();
        a.Range.Init();
        a.Range.Count = count;
        return a;
    }

    public virtual Text TextCreateString(string o, Range range)
    {
        Data data;
        data = this.InfraInfra.DataCreateString(o, range);
        if (data == null)
        {
            return null;
        }

        int count;
        count = 0;
        bool b;
        b = (range == null);
        if (b)
        {
            count = o.Length;
        }
        if (!b)
        {
            count = range.Count;
        }

        Text a;
        a = new Text();
        a.Init();
        a.Data = data;
        a.Range = new Range();
        a.Range.Init();
        a.Range.Count = count;
        return a;
    }

    public virtual bool CheckRange(Text text)
    {
        long dataCount;
        dataCount = text.Data.Count;
        long charCount;
        charCount = dataCount / 2;
        int count;
        count = (int)charCount;

        Range range;
        range = text.Range;
        if (!this.InfraInfra.CheckRange(count, range.Index, range.Count))
        {
            return false;
        }
        return true;
    }

    public virtual bool EqualString(Text text, string other, Range otherRange)
    {
        if (!this.CheckRange(text))
        {
            return false;
        }

        int otherIndex;
        int otherCount;
        otherIndex = 0;
        otherCount = 0;
        bool b;
        b = (otherRange == null);
        if (b)
        {
            otherIndex = 0;
            otherCount = other.Length;
        }
        if (!b)
        {
            otherIndex = otherRange.Index;
            otherCount = otherRange.Count;
            if (!this.InfraInfra.CheckRange(other.Length, otherIndex, otherCount))
            {
                return false;
            }
        }

        int count;
        count = text.Range.Count;
        if (!(count == otherCount))
        {
            return false;
        }

        Data textData;
        textData = text.Data;
        int start;
        start = text.Range.Index;
        int i;
        i = 0;
        while (i < count)
        {
            int index;
            index = start + i;
            int indexA;
            indexA = otherIndex + i;

            char oca;
            oca = this.DataCharGet(textData, index);
            char ocb;
            ocb = other[indexA];
            
            if (!(oca == ocb))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    public virtual bool EqualText(Text text, Text other)
    {
        if (!this.CheckRange(text))
        {
            return false;
        }
        if (!this.CheckRange(other))
        {
            return false;
        }
        
        int count;
        count = text.Range.Count;
        int otherCount;
        otherCount = other.Range.Count;
        if (!(count == otherCount))
        {
            return false;
        }

        Data textData;
        textData = text.Data;
        Data otherData;
        otherData = other.Data;
        int start;
        start = text.Range.Index;
        int otherStart;
        otherStart = other.Range.Index;
        int i;
        i = 0;
        while (i < count)
        {
            int index;
            index = start + i;
            int otherIndex;
            otherIndex = otherStart + i;

            char oca;
            oca = this.DataCharGet(textData, index);
            char ocb;
            ocb = this.DataCharGet(otherData, otherIndex);

            if (!(oca == ocb))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    public virtual string StringCreate(Text text)
    {
        StringCreate o;
        o = new StringCreate();
        o.Init();

        return o.Data(text.Data, text.Range);
    }
}