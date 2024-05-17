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
        n = n * sizeof(char);
        return this.InfraInfra.DataCharGet(data, n);
    }

    public virtual bool DataCharSet(Data data, int index, char value)
    {
        long n;
        n = index;
        n = n * sizeof(char);
        return this.InfraInfra.DataCharSet(data, n, value);
    }

    public virtual Text TextCreate(int count)
    {
        if (count < 0)
        {
            return null;
        }

        long oa;
        oa = count;
        oa = oa * sizeof(char);

        Text a;
        a = new Text();
        a.Init();
        a.Data = new Data();
        a.Data.Count = oa;
        a.Data.Init();
        a.Range = new Range();
        a.Range.Init();
        a.Range.Count = count;
        return a;
    }

    public virtual Data DataCreateString(string o, Range range)
    {
        int index;
        int count;
        index = 0;
        count = 0;
        bool b;
        b = (range == null);
        if (b)
        {
            index = 0;
            count = o.Length;
        }
        if (!b)
        {
            index = range.Index;
            count = range.Count;
            if (!this.InfraInfra.CheckRange(o.Length, index, count))
            {
                return null;
            }
        }

        long oa;
        oa = count;
        oa = oa * sizeof(char);

        Data data;
        data = new Data();
        data.Count = oa;
        data.Init();

        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = o[index + i];

            this.DataCharSet(data, i, oc);
            i = i + 1;
        }

        return data;
    }

    public virtual Text TextCreateString(string o, Range range)
    {
        Data data;
        data = this.DataCreateString(o, range);
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

    public virtual StringData StringDataCreateString(string o)
    {
        StringData a;
        a = new StringData();
        a.Init();
        a.Value = o;
        return a;
    }

    public virtual Text TextCreateStringData(string o, Range range)
    {
        int index;
        int count;
        index = 0;
        count = 0;
        bool b;
        b = (range == null);
        if (b)
        {
            index = 0;
            count = o.Length;
        }
        if (!b)
        {
            index = range.Index;
            count = range.Count;
            if (!this.InfraInfra.CheckRange(o.Length, index, count))
            {
                return null;
            }
        }

        StringData data;
        data = this.StringDataCreateString(o);

        Range aa;
        aa = new Range();
        aa.Init();
        aa.Index = index;
        aa.Count = count;

        Text a;
        a = new Text();
        a.Init();
        a.Data = data;
        a.Range = aa;
        return a;
    }

    public virtual bool CheckRange(Text text)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        Data data;
        data = text.Data;

        Range range;
        range = text.Range;

        long dataCount;
        dataCount = data.Count;
        long charCount;
        charCount = dataCount / 2;
        int count;
        count = (int)charCount;

        if (!infraInfra.CheckRange(count, range.Index, range.Count))
        {
            return false;
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

    public virtual bool Equal(Text left, Text right, Compare compare)
    {
        int o;
        o = compare.Execute(left, right);
        return (o == 0);
    }

    public virtual int Index(Text text, Text other, Compare compare)
    {
        if (!this.CheckRange(text))
        {
            return -1;
        }
        if (!this.CheckRange(other))
        {
            return -1;
        }

        Range textRange;
        textRange = text.Range;

        int textIndex;
        int textCount;
        textIndex = textRange.Index;
        textCount = textRange.Count;

        int otherCount;
        otherCount = other.Range.Count;

        if (textCount < otherCount)
        {
            return -1;
        }

        int k;
        k = -1;
        
        int count;
        count = textCount - otherCount + 1;
        int i;
        i = 0;
        while (k == -1 & i < count)
        {
            int index;
            index = textIndex + i;

            textRange.Index = index;
            textRange.Count = otherCount;

            bool b;
            b = this.Equal(text, other, compare);
            if (b)
            {
                k = i;
            }
            i = i + 1;
        }

        textRange.Index = textIndex;
        textRange.Count = textCount;

        return k;
    }

    public virtual int LastIndex(Text text, Text other, Compare compare)
    {
        if (!this.CheckRange(text))
        {
            return -1;
        }
        if (!this.CheckRange(other))
        {
            return -1;
        }

        Range textRange;
        textRange = text.Range;

        int textIndex;
        int textCount;
        textIndex = textRange.Index;
        textCount = textRange.Count;

        int otherCount;
        otherCount = other.Range.Count;

        if (textCount < otherCount)
        {
            return -1;
        }

        int k;
        k = -1;

        int count;
        count = textCount - otherCount + 1;
        int i;
        i = 0;
        while (k == -1 & i < count)
        {
            int index;
            index = textIndex + count - 1 - i;

            textRange.Index = index;
            textRange.Count = otherCount;

            bool b;
            b = this.Equal(text, other, compare);
            if (b)
            {
                k = i;
            }
            i = i + 1;
        }

        textRange.Index = textIndex;
        textRange.Count = textCount;

        return k;
    }
}