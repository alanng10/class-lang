namespace Avalon.Text;

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

            object ka;
            ka = null;
            long count;
            count = 0;

            if (!(value == null))
            {
                ka = value.Value;
                count = value.Count * sizeof(uint);
            }

            this.Value = ka;
            this.Count = count;
        }
    }

    internal virtual String ValueStringData { get; set; }

    public override bool Set(long index, long value)
    {
        return false;
    }
}