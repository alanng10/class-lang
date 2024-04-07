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
        if (!(index < 0) & (index < o.Length))
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

    public virtual bool C_Equal(string o, string other)
    {
        return o == other;
    }
}