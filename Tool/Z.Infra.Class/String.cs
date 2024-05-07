namespace Z.Infra.Class;

public class String : Any
{
    public static readonly String This = ShareCreate();

    private static String ShareCreate()
    {
        String share;
        share = new String();
        Any a;
        a = share;
        a.Init();
        return share;
    }

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

    public virtual bool S_Count(string o, int value)
    {
        if (o == null)
        {
            throw new Exception("Null Reference Exception");
        }
        return true;
    }

    public virtual int C_Char(string o, int index)
    {
        if (!this.InfraInfra.CheckIndex(o.Length, index))
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
        int index;
        int count;
        index = range.Index;
        count = range.Count;
        if (!this.InfraInfra.CheckRange(o.Length, index, count))
        {
            return null;
        }
        return o.Substring(index, count);
    }

    public virtual int C_Index(string o, Range range, string other, Range otherRange)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

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
            thisIndex = range.Index;
            thisCount = range.Count;
            if (!infraInfra.CheckRange(o.Length, thisIndex, thisCount))
            {
                return -1;
            }
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
            otherIndex = otherRange.Index;
            otherCount = otherRange.Count;
            if (!infraInfra.CheckRange(other.Length, otherIndex, otherCount))
            {
                return -1;
            }
        }

        if (thisCount < otherCount)
        {
            return -1;
        }

        int count;
        count = thisCount - otherCount;
        int i;
        i = 0;
        while (i < count)
        {
            int index;
            index = thisIndex + i;

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
                oca = o[index + iA];
                ocb = other[otherIndex + iA];
                
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

    public virtual bool C_Equal(string o, Range range, string other, Range otherRange)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

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
            thisIndex = range.Index;
            thisCount = range.Count;
            if (!infraInfra.CheckRange(o.Length, thisIndex, thisCount))
            {
                return false;
            }
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
            otherIndex = otherRange.Index;
            otherCount = otherRange.Count;
            if (!infraInfra.CheckRange(other.Length, otherIndex, otherCount))
            {
                return false;
            }
        }

        if (!(thisCount == otherCount))
        {
            return false;
        }

        int count;
        count = thisCount;
        int i;
        i = 0;
        while (i < count)
        {
            char oca;
            char ocb;
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