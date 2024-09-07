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
        this.CharFormInfra = CharFormInfra.This;
        this.StringComp = StringComp.This;
        this.TextCode = global::Avalon.Text.Code.This;
        this.StringValue = StringValue.This;

        this.NewLine = this.StringComp.CreateChar('\n', 1);
        this.PathCombine = this.StringComp.CreateChar('/', 1);
        this.Zero = this.StringComp.CreateChar(0, 0);

        this.PosAddSign = this.StringComp.CreateChar('+', 1);
        this.PosSubSign = this.StringComp.CreateChar('-', 1);

        this.BoolFalseString = this.S("false");
        this.BoolTrueString = this.S("true");

        this.NiteCharForm = new NiteCharForm();
        this.NiteCharForm.Init();
        this.SiteCharForm = new SiteCharForm();
        this.SiteCharForm.Init();
        return true;
    }

    public virtual String BoolFalseString { get; set; }
    public virtual String BoolTrueString { get; set; }
    public virtual String NewLine { get; set; }
    public virtual String PathCombine { get; set; }
    public virtual String Zero { get; set; }
    public virtual String PosAddSign { get; set; }
    public virtual String PosSubSign { get; set; }
    public virtual CharForm NiteCharForm { get; set; }
    public virtual CharForm SiteCharForm { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    private CharFormInfra CharFormInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual Code TextCode { get; set; }
    protected virtual StringValue StringValue { get; set; }

    public virtual bool Digit(long o)
    {
        return this.CharFormInfra.Digit(o);
    }

    public virtual bool HexAlpha(long o, bool upperCase)
    {
        return this.CharFormInfra.HexAlpha(o, upperCase);
    }

    public virtual bool Alpha(long o, bool upperCase)
    {
        return this.CharFormInfra.Alpha(o, upperCase);
    }

    public virtual bool Range(long first, long last, long o)
    {
        return this.CharFormInfra.IsInRange(first, last, o);
    }

    public virtual uint DataCharGet(Data data, long index)
    {
        long n;
        n = index;
        n = n * sizeof(uint);
        return this.InfraInfra.DataCharGet(data, n);
    }

    public virtual bool DataCharSet(Data data, long index, long value)
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

    public virtual long DigitValue(long oc, long varBase, bool upperCase)
    {
        long oa;
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
        long oaa;
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

        if (this.Digit(oc))
        {
            long ooa;
            ooa = oc - '0';
            if (!(ooa < oa))
            {
                return -1;
            }

            return ooa;
        }

        if (!this.Alpha(oc, upperCase))
        {
            return -1;
        }

        long oob;
        oob = oc - oca;
        if (!(oob < oaa))
        {
            return -1;
        }

        return oob + 10;
    }

    public virtual uint DigitChar(long digit, long letterStart)
    {
        long n;
        n = 0;
        bool b;
        b = (digit < 10);
        if (b)
        {
            n = '0' + digit;
        }
        if (!b)
        {
            long m;
            m = digit - 10;
            n = letterStart + m;
        }
        uint a;
        a = (uint)n;
        return a;
    }

    public virtual String StringCreate(Text text)
    {
        return this.StringComp.CreateData(text.Data, text.Range);
    }

    public virtual bool Same(Text lite, Text rite, InfraLess less)
    {
        long o;
        o = less.Execute(lite, rite);
        return (o == 0);
    }

    public virtual bool Start(Text text, Text other, InfraLess less)
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
        a = this.Same(text, other, less);

        range.Count = count;

        return a;
    }

    public virtual bool End(Text text, Text other, InfraLess less)
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
        a = this.Same(text, other, less);

        range.Index = index;
        range.Count = count;

        return a;
    }

    public virtual long Index(Text text, Text other, InfraLess less)
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

        long textIndex;
        long textCount;
        textIndex = textRange.Index;
        textCount = textRange.Count;

        long otherCount;
        otherCount = other.Range.Count;

        if (textCount < otherCount)
        {
            return -1;
        }

        long k;
        k = -1;
        
        long count;
        count = textCount - otherCount + 1;
        long i;
        i = 0;
        while (k == -1 & i < count)
        {
            long index;
            index = textIndex + i;

            textRange.Index = index;
            textRange.Count = otherCount;

            bool b;
            b = this.Same(text, other, less);
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

    public virtual long LastIndex(Text text, Text other, InfraLess less)
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

        long textIndex;
        long textCount;
        textIndex = textRange.Index;
        textCount = textRange.Count;

        long otherCount;
        otherCount = other.Range.Count;

        if (textCount < otherCount)
        {
            return -1;
        }

        long k;
        k = -1;

        long count;
        count = textCount - otherCount + 1;
        long i;
        i = 0;
        while (k == -1 & i < count)
        {
            long index;
            index = textIndex + count - 1 - i;

            textRange.Index = index;
            textRange.Count = otherCount;

            bool b;
            b = this.Same(text, other, less);
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

    public virtual Array Limit(Text text, Text limit, InfraLess less)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        Data data;
        data = text.Data;

        Range textRange;
        textRange = text.Range;

        long delimitCount;
        delimitCount = limit.Range.Count;

        long kka;
        kka = textRange.Index;

        long kkb;
        kkb = textRange.Count;

        long count;
        count = 0;

        long oo;
        oo = this.Index(text, limit, less);
        while (!(oo < 0))
        {
            count = count + 1;

            long kaa;
            kaa = oo + delimitCount;

            textRange.Index = textRange.Index + kaa;
            textRange.Count = textRange.Count - kaa;

            oo = this.Index(text, limit, less);
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

        long i;
        i = 0;
        while (i < count)
        {
            oo = this.Index(text, limit, less);

            rangeA.Index = textRange.Index;
            rangeA.Count = oo;

            Text line;
            line = this.TextCreateDataRange(data, rangeA);

            array.SetAt(i, line);

            long kab;
            kab = oo + delimitCount;

            textRange.Index = textRange.Index + kab;
            textRange.Count = textRange.Count - kab;

            i = i + 1;
        }

        long ka;
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

    public virtual Text Join(Array array, Text join)
    {
        long k;
        k = 0;

        Range joinRange;
        joinRange = join.Range;

        long joinCount;
        joinCount = joinRange.Count;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            if (0 < i)
            {
                k = k + joinCount;
            }

            Text ka;
            ka = (Text)array.GetAt(i);

            k = k + ka.Range.Count;

            i = i + 1;
        }

        Text text;
        text = this.TextCreate(k);

        Data dest;
        dest = text.Data;

        Data joinData;
        joinData = join.Data;

        long joinIndex;
        joinIndex = joinRange.Index;

        k = 0;
        i = 0;
        while (i < count)
        {
            if (0 < i)
            {
                this.Copy(dest, k, joinData, joinIndex, joinCount);

                k = k + joinCount;
            }

            Text ka;
            ka = (Text)array.GetAt(i);

            Data kaData;
            kaData = ka.Data;

            Range kaRange;
            kaRange = ka.Range;

            long kaCount;
            kaCount = kaRange.Count;

            this.Copy(dest, k, kaData, kaRange.Index, kaCount);

            k = k + kaCount;

            i = i + 1;
        }

        return text;
    }

    public virtual Text Replace(Text text, Text delimit, Text join, InfraLess less)
    {
        Array array;
        array = this.Limit(text, delimit, less);

        Text k;
        k = this.Join(array, join);

        Text a;
        a = k;
        return a;
    }

    public virtual bool Form(Text dest, Text source, CharForm form)
    {
        if (!this.ValidRange(dest))
        {
            return false;
        }
        if (!this.ValidRange(source))
        {
            return false;
        }

        long count;
        count = dest.Range.Count;

        if (!(count == source.Range.Count))
        {
            return false;
        }

        Data sourceData;
        Data destData;
        sourceData = source.Data;
        destData = dest.Data;

        long sourceIndex;
        long destIndex;
        sourceIndex = source.Range.Index;
        destIndex = dest.Range.Index;

        long i;
        i = 0;
        while (i < count)
        {
            long n;
            n = this.DataCharGet(sourceData, sourceIndex + i);

            n = form.Execute(n);

            this.DataCharSet(destData, destIndex + i, n);

            i = i + 1;
        }

        return true;
    }

    public virtual bool Copy(Data dest, long destIndex, Data source, long sourceIndex, long count)
    {
        long ka;
        ka = sizeof(uint);

        return this.InfraInfra.DataCopy(dest, destIndex * ka, source, sourceIndex * ka, count * ka);
    }

    public virtual Data Code(CodeKind innKind, CodeKind outKind, Data data, Range range)
    {
        Code code;
        code = this.TextCode;

        if (!code.ValidKind(innKind, outKind))
        {
            return null;
        }

        long resultCount;
        resultCount = code.ExecuteCount(innKind, outKind, data, range);

        Data result;
        result = new Data();
        result.Count = resultCount;
        result.Init();

        code.ExecuteResult(result, 0, innKind, outKind, data, range);

        return result;
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

    public virtual String S(string o)
    {
        return this.StringValue.Execute(o);
    }
}