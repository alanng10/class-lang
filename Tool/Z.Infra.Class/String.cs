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
        if (!this.InfraInfra.CheckRange(o.Length, index, 1))
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

    public virtual bool C_Equal(string o, Range range, string other, int otherIndex)
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
            thisIndex = range.Index;
            thisCount = range.Count;
            if (!this.InfraInfra.CheckRange(o.Length, thisIndex, thisCount))
            {
                return false;
            }
        }

        if (!this.InfraInfra.CheckRange(other.Length, otherIndex, thisCount))
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