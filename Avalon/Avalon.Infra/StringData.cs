namespace Avalon.Infra;

public class StringData : Data
{
    protected override bool InitValue()
    {
        return true;
    }

    public override long Count
    {
        get
        {
            long a;
            a = this.ValueString.CountData;
            a = a * sizeof(uint);
            return a;
        }
        set
        {
        }
    }

    public virtual String ValueString { get; set; }

    public override int Get(long index)
    {
        if (!this.Valid(index))
        {
            return -1;
        }

        int a;
        a = this.ValueString.DataData.Get(index);
        return a;
    }

    public override bool Set(long index, int value)
    {
        return false;
    }
}