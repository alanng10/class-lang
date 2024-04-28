namespace Avalon.Infra;

public class Data : Any
{
    public override bool Init()
    {
        base.Init();
        this.Value = new byte[this.Count];
        return true;
    }

    public virtual long Count { get { return __D_Count; } set { __D_Count = value; } }
    protected long __D_Count;
    public virtual byte[] Value { get; set; }

    public virtual int Get(long index)
    {
        if (!this.Contain(index))
        {
            return -1;
        }
        return this.Value[index];
    }

    public virtual bool Set(long index, int value)
    {
        if (!this.Contain(index))
        {
            return false;
        }
        this.Value[index] = (byte)value;
        return true;
    }

    public virtual bool Contain(long index)
    {
        return ((!(index < 0)) & (index < this.Count));
    }
}