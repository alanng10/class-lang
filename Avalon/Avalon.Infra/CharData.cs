namespace Avalon.Infra;

public class CharData : Any
{
    public override bool Init()
    {
        base.Init();
        this.Value = new char[this.Count];
        return true;
    }

    public virtual int Count { get; set; }

    public virtual char[] Value { get; set; }

    public virtual int Get(int index)
    {
        if (!this.Contain(index))
        {
            return -1;
        }
        return this.Value[index];
    }

    public virtual bool Set(int index, int value)
    {
        if (!this.Contain(index))
        {
            return false;
        }
        this.Value[index] = (char)value;
        return true;
    }

    public virtual bool Contain(int index)
    {
        return ((!(index < 0)) | index < this.Count);
    }
}