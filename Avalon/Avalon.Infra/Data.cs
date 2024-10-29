namespace Avalon.Infra;

public class Data : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = Infra.This;
        this.InitValue();
        return true;
    }

    public virtual long Count { get; set; }
    protected virtual Infra InfraInfra { get; set; }
    
    public virtual object Value { get; set; }

    protected virtual bool InitValue()
    {
        this.Value = new byte[this.Count];
        return true;
    }

    public virtual long Get(long index)
    {
        if (!this.Valid(index))
        {
            return -1;
        }

        byte[] k;
        k = (byte[])this.Value;

        return k[index];
    }

    public virtual bool Set(long index, long value)
    {
        if (!this.Valid(index))
        {
            return false;
        }

        byte[] k;
        k = (byte[])this.Value;

        k[index] = (byte)value;
        return true;
    }

    public virtual bool Valid(long index)
    {
        return this.InfraInfra.ValidIndex(this.Count, index);
    }
}