namespace Avalon.Infra;

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
        this.ByteBitCount = 8;
        this.IntByteCount = sizeof(long);
        this.MidByteCount = sizeof(int);
        this.UShortByteCount = sizeof(ushort);

        long o;
        o = 1;
        o = o << 60;
        this.IntCapValue = o;
        this.NewLine = '\n';
        this.PathCombine = '/';
        return true;
    }

    public virtual int ByteBitCount { get; set; }
    public virtual int IntByteCount { get; set; }
    public virtual int MidByteCount { get; set; }
    public virtual int UShortByteCount { get; set; }
    public virtual long IntCapValue { get; set; }
    public virtual char NewLine { get; set; }
    public virtual char PathCombine { get; set; }

    public virtual bool IndexRange(Range range, int index)
    {
        range.Index = index;        
        range.Count = 1;
        return true;
    }

    public virtual bool CheckRange(int count, Range range)
    {
        int index;
        int countA;
        index = range.Index;
        countA = range.Count;
        if (index < 0)
        {
            return false;
        }
        if (countA < 0)
        {
            return false;
        }
        if (count < index + countA)
        {
            return false;
        }
        return true;
    }

    public virtual bool CheckLongRange(long count, DataRange range)
    {
        long index;
        long countA;
        index = range.Index;
        countA = range.Count;
        if (index < 0)
        {
            return false;
        }
        if (countA < 0)
        {
            return false;
        }
        if (count < index + countA)
        {
            return false;
        }
        return true;
    }
}