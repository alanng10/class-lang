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
    public virtual object Value
    {
        get
        {
            return this.ValueData;
        }
        set
        {
        }
    }

    internal virtual byte[] ValueData { get; set; }

    protected virtual bool InitValue()
    {
        this.ValueData = new byte[this.Count];
        return true;
    }

    public virtual int Get(long index)
    {
        if (!this.Valid(index))
        {
            return -1;
        }
        return this.ValueData[index];
    }

    public virtual bool Set(long index, int value)
    {
        if (!this.Valid(index))
        {
            return false;
        }
        this.ValueData[index] = (byte)value;
        return true;
    }

    public virtual bool Valid(long index)
    {
        return this.InfraInfra.ValidIndexInt(this.Count, index);
    }
}