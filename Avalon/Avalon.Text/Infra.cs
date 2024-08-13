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
        this.StringComp = StringComp.This;
        this.BoolFalseString = "false";
        this.BoolTrueString = "true";
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    public virtual string BoolFalseString { get; set; }
    public virtual string BoolTrueString { get; set; }

    public virtual bool IsDigit(uint o)
    {
        return this.IsInRange('0', '9', o);
    }

    public virtual bool IsHexLetter(uint o, bool upperCase)
    {
        uint first;
        first = 'a';
        uint last;
        last = 'f';
        if (upperCase)
        {
            first = 'A';
            last = 'F';
        }
        return this.IsInRange(first, last, o);
    }

    public virtual bool IsLetter(uint o, bool upperCase)
    {
        uint first;
        first = 'a';
        uint last;
        last = 'z';
        if (upperCase)
        {
            first = 'A';
            last = 'Z';
        }
        return this.IsInRange(first, last, o);
    }

    public virtual bool IsInRange(uint first, uint last, uint o)
    {
        if (last < first)
        {
            return false;
        }
        return !((o < first) | (last < o));
    }

    public virtual uint DataCharGet(Data data, long index)
    {
        long n;
        n = index;
        n = n * sizeof(uint);
        return this.InfraInfra.DataCharGet(data, n);
    }

    public virtual bool DataCharSet(Data data, long index, uint value)
    {
        long n;
        n = index;
        n = n * sizeof(uint);
        return this.InfraInfra.DataCharSet(data, n, value);
    }

    public virtual Text TextCreate(long count)
    {
        if (count < 0)
        {
            return null;
        }

        long oa;
        oa = count;
        oa = oa * sizeof(uint);

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

    public virtual StringData StringDataCreateString(String o)
    {
        StringData a;
        a = new StringData();
        a.Init();
        a.ValueString = o;
        return a;
    }

    public virtual Text TextCreateStringData(String o, Range range)
    {
        StringComp stringComp;
        stringComp = this.StringComp;

        long totalCount;
        totalCount = stringComp.Count(o);

        long index;
        long count;
        index = 0;
        count = 0;
        bool b;
        b = (range == null);
        if (b)
        {
            index = 0;
            count = totalCount;
        }
        if (!b)
        {
            index = range.Index;
            count = range.Count;
            if (!this.InfraInfra.ValidRange(totalCount, index, count))
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

    public virtual bool ValidRange(Text text)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        Data data;
        data = text.Data;

        Range range;
        range = text.Range;

        long dataCount;
        dataCount = data.Count;
        long totalCount;
        totalCount = dataCount / sizeof(uint);
        
        if (!infraInfra.ValidRange(totalCount, range.Index, range.Count))
        {
            return false;
        }
        return true;
    }

    public virtual int DigitValue(uint oc, int varBase, bool upperCase)
    {
        int oa;
        oa = 0;
        bool b;
        b = (varBase < 10);
        if (b)
        {
            oa = varBase;
        }
        if (!b)
        {
            oa = 10;
        }
        int oaa;
        oaa = 0;
        if (!b)
        {
            oaa = varBase - 10;
        }
        uint oca;
        oca = 'a';
        if (upperCase)
        {
            oca = 'A';
        }

        if (this.IsDigit(oc))
        {
            int ooa;
            ooa = (int)(oc - '0');
            if (!(ooa < oa))
            {
                return -1;
            }

            return ooa;
        }

        if (!this.IsLetter(oc, upperCase))
        {
            return -1;
        }

        int oob;
        oob = (int)(oc - oca);
        if (!(oob < oaa))
        {
            return -1;
        }

        return oob + 10;
    }

    public virtual char DigitChar(int digit, char letterStart)
    {
        int n;
        n = 0;
        bool b;
        b = (digit < 10);
        if (b)
        {
            n = '0' + digit;
        }
        if (!b)
        {
            int m;
            m = digit - 10;
            n = letterStart + m;
        }
        char a;
        a = (char)n;
        return a;
    }

    public virtual String StringCreate(Text text)
    {
        return this.StringComp.CreateData(text.Data, text.Range);
    }

    public virtual bool Equal(Text left, Text right, InfraCompare compare)
    {
        int o;
        o = compare.Execute(left, right);
        return (o == 0);
    }

    public virtual bool Start(Text text, Text other, InfraCompare compare)
    {
        Range range;
        range = text.Range;

        long count;
        count = range.Count;
        long otherCount;
        otherCount = other.Range.Count;
        
        if (count < otherCount)
        {
            return false;
        }

        range.Count = otherCount;

        bool a;
        a = this.Equal(text, other, compare);

        range.Count = count;

        return a;
    }

    public virtual bool End(Text text, Text other, InfraCompare compare)
    {
        Range range;
        range = text.Range;

        long count;
        count = range.Count;
        long otherCount;
        otherCount = other.Range.Count;

        if (count < otherCount)
        {
            return false;
        }

        long index;
        index = range.Index;
        
        long end;
        end = index + count;

        range.Index = end - otherCount;
        range.Count = otherCount;

        bool a;
        a = this.Equal(text, other, compare);

        range.Index = index;
        range.Count = count;

        return a;
    }

    public virtual int Index(Text text, Text other, InfraCompare compare)
    {
        if (!this.ValidRange(text))
        {
            return -1;
        }
        if (!this.ValidRange(other))
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

    public virtual int LastIndex(Text text, Text other, InfraCompare compare)
    {
        if (!this.ValidRange(text))
        {
            return -1;
        }
        if (!this.ValidRange(other))
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

    public virtual Array TextArraySplit(Text text, Text delimit, InfraCompare compare)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        Data data;
        data = text.Data;

        Range textRange;
        textRange = text.Range;

        int delimitCount;
        delimitCount = delimit.Range.Count;

        int kka;
        kka = textRange.Index;

        int kkb;
        kkb = textRange.Count;

        int count;
        count = 0;

        int oo;
        oo = this.Index(text, delimit, compare);
        while (!(oo < 0))
        {
            count = count + 1;

            int kaa;
            kaa = oo + delimitCount;

            textRange.Index = textRange.Index + kaa;
            textRange.Count = textRange.Count - kaa;

            oo = this.Index(text, delimit, compare);
        }

        Array array;
        array = new Array();
        array.Count = count + 1;
        array.Init();

        Range rangeA;
        rangeA = new Range();
        rangeA.Init();

        textRange.Index = kka;
        textRange.Count = kkb;

        int i;
        i = 0;
        while (i < count)
        {
            oo = this.Index(text, delimit, compare);

            rangeA.Index = textRange.Index;
            rangeA.Count = oo;

            Text line;
            line = this.TextCreateDataRange(data, rangeA);

            array.SetAt(i, line);

            int kab;
            kab = oo + delimitCount;

            textRange.Index = textRange.Index + kab;
            textRange.Count = textRange.Count - kab;

            i = i + 1;
        }

        int ka;
        ka = kka + kkb - textRange.Index;

        rangeA.Index = textRange.Index;
        rangeA.Count = ka;

        textRange.Index = kka;
        textRange.Count = kkb;

        Text lastLine;
        lastLine = this.TextCreateDataRange(data, rangeA);

        array.SetAt(count, lastLine);

        return array;
    }

    private Text TextCreateDataRange(Data data, Range range)
    {
        Range aa;
        aa = new Range();
        aa.Init();
        aa.Index = range.Index;
        aa.Count = range.Count;
        
        Text a;
        a = new Text();
        a.Init();
        a.Data = data;
        a.Range = aa;
        return a;
    }
}