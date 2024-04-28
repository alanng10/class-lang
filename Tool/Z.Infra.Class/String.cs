namespace Z.Infra.Class;

public class String : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public virtual int G_Count(string o)
    {
        return o.Length;
    }

    public virtual int C_Char(string o, int index)
    {
        if (!(!(index < 0) & (index < o.Length)))
        {
            return -1;
        }
        char oc;
        oc = o[index];
        int a;
        a = oc;
        return a;
    }

    public virtual string C_Substring(string o, Range range)
    {
        if (!this.InfraInfra.CheckRange(o.Length, range))
        {
            return null;
        }
        return o.Substring(range.Index, range.Count);
    }

    public virtual bool C_Equal(string o, Range range, string other, Range otherRange)
    {
        int thisIndex;
        int thisCount;
        thisIndex = 0;
        thisCount = 0;
        bool ba;
        ba = (range == null);
        if (ba)
        {
            thisIndex = 0;
            thisCount = o.Length;
        }
        if (!ba)
        {
            if (!this.InfraInfra.CheckRange(o.Length, range))
            {
                return false;
            }
            thisIndex = range.Index;
            thisCount = range.Count;
        }

        int otherIndex;
        int otherCount;
        otherIndex = 0;
        otherCount = 0;
        bool bb;
        bb = (otherRange == null);
        if (bb)
        {
            otherIndex = 0;
            otherCount = other.Length;
        }
        if (!bb)
        {
            if (!this.InfraInfra.CheckRange(other.Length, otherRange))
            {
                return false;
            }
            otherIndex = otherRange.Index;
            otherCount = otherRange.Count;
        }

        if (!(thisCount == otherCount))
        {
            return false;
        }

        char oca;
        char ocb;
        int i;
        i = 0;
        while (i < thisCount)
        {
            oca = o[thisIndex + i];
            ocb = other[otherIndex + i];
            if (!(oca == ocb))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }
}