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
            a = this.Value.Length;
            a = a * sizeof(char);
            return a;
        }
        set
        {
        }
    }

    public new virtual string Value { get; set; }

    public override int Get(long index)
    {
        if (!this.Contain(index))
        {
            return -1;
        }

        int oa;
        oa = sizeof(char);

        long ka;
        ka = index / oa;

        long kb;
        kb = ka * oa;

        long kc;
        kc = index - kb;

        int n;
        n = (int)ka;

        char oc;
        oc = this.Value[n];
        
        int a;
        a = oc;

        if (0 < kc)
        {
            a = a >> 8;
        }

        int mask;
        mask = (1 << 8) - 1;

        a = a & mask;

        return a;
    }

    public override bool Set(long index, int value)
    {
        return false;
    }
}