namespace Avalon.Console;

public class StringInn : Inn
{
    public override bool Init()
    {
        base.Init();
        this.StringComp = StringComp.This;
        this.Range = new Range();
        this.Range.Init();
        return true;
    }

    public virtual String String { get; set; }
    public virtual long Index { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual Range Range { get; set; }

    public override String Read()
    {
        StringComp stringComp;
        stringComp = this.StringComp;

        String o;
        o = this.String;
        long index;
        index = this.Index;

        Range range;
        range = this.Range;

        String a;
        a = null;

        long u;
        u = this.StringIndex(index, '\n');

        bool b;
        b = (u < 0);

        if (b)
        {
            long end;
            end = stringComp.Count(o);

            long countA;
            countA = end - index;

            range.Index = index;
            range.Count = countA;

            a = stringComp.CreateString(o, range);

            index = end;
        }
        if (!b)
        {
            long count;
            count = u - index;

            range.Index = index;
            range.Count = count;

            a = stringComp.CreateString(o, range);

            index = index + count + 1;
        }

        this.Index = index;

        return a;
    }

    public virtual bool Reset()
    {
        this.Index = 0;
        return true;
    }

    private long StringIndex(long index, uint n)
    {
        StringComp stringComp;
        stringComp = this.StringComp;

        String o;
        o = this.String;

        long count;
        count = stringComp.Count(o);

        long i;
        i = index;
        while (i < count)
        {
            uint oc;
            oc = (uint)stringComp.Char(o, i);

            if (oc == n)
            {
                return i;
            }

            i = i + 1;
        }

        return -1;
    }
}