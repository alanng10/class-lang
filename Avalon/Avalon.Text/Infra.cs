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
        return this.InfraInfra.DataCharGet(data, index * 2);
    }

    public virtual bool DataCharSet(Data data, int index, char value)
    {
        return this.InfraInfra.DataCharSet(data, index * 2, value);
    }

    public virtual Text TextCreate(int count)
    {
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

    public virtual string StringCreate(Text text)
    {
        if (!this.CheckRange(text))
        {
            return null;
        }
        Range range;
        range = text.Range;
        string a;
        a = this.InternIntern.StringCreateData(text.Data.Value, range.Index, range.Count);
        return a;
    }

    public virtual bool CheckRange(Text text)
    {
        int arrayCount;
        arrayCount = (int)text.Data.Count;

        Range range;
        range = text.Range;
        if (!this.InfraInfra.CheckRange(arrayCount, range.Index, range.Count))
        {
            return false;
        }
        return true;
    }
}