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

        long ka;
        ka = index / 2;

        long kb;
        kb = ka * 2;

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
}