namespace Avalon.Infra;

public class StringData : Data
{
    protected override bool InitValue()
    {
        return true;
    }

    public virtual String ValueString
    {
        get
        {
            return this.ValueStringData;
        }
        set
        {
            this.ValueStringData = value;

            byte[] array;
            array = null;
            long count;
            count = 0;

            if (!(value == null))
            {
                array = value.Data.Value;
                count = value.Count * sizeof(uint);
            }

            this.Value = array;
            this.Count = count;
        }
    }

    internal virtual String ValueStringData { get; set; }

    public override long Get(long index)
    {
        if (!this.Valid(index))
        {
            return -1;
        }

        long a;
        a = this.ValueString.Data.Get(index);
        return a;
    }

    public override bool Set(long index, long value)
    {
        return false;
    }
}