namespace Class.Infra;

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

    public virtual bool IndexRange(Range range, int index)
    {
        range.Start = index;
        range.End = index + 1;
        return true;
    }

    public virtual int Count(Range range)
    {
        return range.End - range.Start;
    }

    public virtual bool CheckRange(int count, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;
        if (start < 0)
        {
            return false;
        }
        if (end < start)
        {
            return false;
        }
        if (count < end)
        {
            return false;
        }
        return true;
    }
}