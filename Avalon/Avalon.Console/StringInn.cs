namespace Avalon.Console;

public class StringInn : Inn
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.StringComp = StringComp.This;
        this.Range = new Range();
        this.Range.Init();
        return true;
    }

    public virtual String String { get; set; }
    public virtual long Index { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual Range Range { get; set; }

    public override String Read()
    {
        StringComp stringComp;
        stringComp = this.StringComp;

        String k;
        k = this.String;
        long index;
        index = this.Index;

        long count;
        count = stringComp.Count(k);

        if (!this.InfraInfra.ValidIndex(count, index))
        {
            return null;
        }

        Range range;
        range = this.Range;

        String a;
        a = null;

        long u;
        u = this.StringIndex(k, index, '\n');

        bool b;
        b = (u < 0);

        if (b)
        {
            long countA;
            countA = count - index;

            range.Index = index;
            range.Count = countA;

            a = stringComp.CreateString(k, range);

            index = count;
        }
        if (!b)
        {
            long countB;
            countB = u - index;

            range.Index = index;
            range.Count = countB;

            a = stringComp.CreateString(k, range);

            index = index + countB + 1;
        }

        this.Index = index;

        return a;
    }

    public virtual bool Reset()
    {
        this.Index = 0;
        return true;
    }

    private long StringIndex(String k, long index, long n)
    {
        StringComp stringComp;
        stringComp = this.StringComp;

        long count;
        count = stringComp.Count(k);

        long i;
        i = index;
        while (i < count)
        {
            long ka;
            ka = stringComp.Char(k, i);

            if (ka == n)
            {
                return i;
            }

            i = i + 1;
        }

        return -1;
    }
}