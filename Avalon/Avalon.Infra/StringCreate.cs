namespace Avalon.Infra;

public class StringCreate : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = Infra.This;
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual Infra InfraInfra { get; set; }

    public virtual string Char(char c)
    {
        return c.ToString();
    }

    public virtual string CharCount(char c, int count)
    {
        return new string(c, count);
    }

    public virtual string Data(Data data, Range range)
    {
        long dataCount;
        dataCount = data.Count;
        long charCount;
        charCount = dataCount / 2;
        int totalCount;
        totalCount = (int)charCount;

        int index;
        int count;
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
            if (!this.InfraInfra.CheckRange(totalCount, index, count))
            {
                return null;
            }
        }

        string a;
        a = this.InternIntern.StringCreateData(data.Value, index, count);
        return a;
    }
}