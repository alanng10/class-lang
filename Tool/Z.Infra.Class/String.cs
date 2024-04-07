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
        return o[index];
    }

    public virtual string C_SubString(string o, Range range)
    {
        if (!this.InfraInfra.CheckRange(o.Length, range))
        {
            return null;
        }
        return o.Substring(range.Index, range.Count);
    }

    public virtual bool C_Equal(string o, string other, Range range)
    {
        int index;
        int count;
        index = 0;
        count = 0;
        bool b;
        b = (range == null);
        if (b)
        {
            index = 0;
            count = o.Length;  
        }
        if (!b)
        {
            if (!this.InfraInfra.CheckRange(o.Length, range))
            {
                return false;
            }
            index = range.Index;
            count = range.Count;
        }

        if (!(count == other.Length))
        {
            return false;
        }

        char oca;
        char ocb;
        int i;
        i = 0;
        while (i < count)
        {
            oca = o[index + i];
            ocb = other[i];
            if (!(oca == ocb))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }
}