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
        if (data is StringData)
        {
            StringData aa;
            aa = (StringData)data;
            char oc;
            oc = (char)aa.GetChar(index);
            return oc;
        }
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
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        Data data;
        data = text.Data;

        Range range;
        range = text.Range;

        if (data is StringData)
        {
            StringData aa;
            aa = (StringData)data;

            bool b;
            b = infraInfra.CheckRange(aa.Value.Length, range.Index, range.Count);
            return b;
        }

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

    public virtual bool Equal(Text text, Text other)
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

    public virtual int Index(Text text, Text other)
    {
        int textIndex;
        int textCount;
        textIndex = text.Range.Index;
        textCount = text.Range.Count;

        int otherIndex;
        int otherCount;
        otherIndex = other.Range.Index;
        otherCount = other.Range.Count;

        if (textCount < otherCount)
        {
            return -1;
        }

        Data textData;
        textData = text.Data;
        Data otherData;
        otherData = other.Data;

        int count;
        count = textCount - otherCount + 1;
        int i;
        i = 0;
        while (i < count)
        {
            int index;
            index = textIndex + i;

            bool b;
            b = false;

            int countA;
            countA = otherCount;
            int iA;
            iA = 0;
            while (!b & iA < countA)
            {
                char oca;
                char ocb;
                oca = this.DataCharGet(textData, index + iA);
                ocb = this.DataCharGet(otherData, otherIndex + iA);

                if (!(oca == ocb))
                {
                    b = true;
                }
                iA = iA + 1;
            }

            if (!b)
            {
                return i;
            }
            i = i + 1;
        }

        return -1;
    }
}