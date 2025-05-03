namespace Avalon.Math;

public partial class Math : Any
{
    public static Math This { get; } = ShareCreate();

    private static Math ShareCreate()
    {
        Math share;
        share = new Math();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public virtual long Value(Comp comp)
    {
        long cand;
        cand = comp.Cand;
        long expo;
        expo = comp.Expo;

        double internValue;
        internValue = this.InternValueComp(cand, expo);

        return this.ValueInternValue(internValue);
    }

    public virtual long ValueTen(Comp comp)
    {
        long cand;
        cand = comp.Cand;
        long expo;
        expo = comp.Expo;

        double internValue;
        internValue = this.InternValueTenComp(cand, expo);

        return this.ValueInternValue(internValue);
    }

    public virtual bool Comp(Comp result, long value)
    {
        long ka;
        ka = value;
        ka = ka << 14;
        ka = ka >> 14;

        long kb;
        kb = value;
        kb = kb << 4;
        kb = kb >> 54;

        result.Cand = ka;
        result.Expo = kb;
        return true;
    }

    public virtual long Less(long valueA, long valueB)
    {
        double ka;
        double kb;
        ka = this.InternValue(valueA);
        kb = this.InternValue(valueB);

        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        if (!this.ValidIntern(kb))
        {
            return -1;
        }

        bool b;
        b = ka < kb;

        long a;
        a = 0;
        if (b)
        {
            a = 1;
        }
        return a;
    }

    private long ValueInternValue(double internValue)
    {
        if (!this.ValidIntern(internValue))
        {
            return -1;
        }

        if (internValue == 0)
        {
            return 0;
        }

        bool negate;
        negate = internValue < 0;

        double ka;
        ka = internValue;

        if (negate)
        {
            ka = -ka;
        }

        double kb;
        kb = SystemMath.Log2(ka);

        if (!this.ValidIntern(kb))
        {
            return -1;
        }

        long kaa;
        kaa = (long)kb;

        long kd;
        kd = 48 - kaa;

        double ke;
        ke = SystemMath.Pow(2, kd);

        if (!this.ValidIntern(ke))
        {
            return -1;
        }

        double kf;
        kf = ka * ke;

        if (!this.ValidIntern(kf))
        {
            return -1;
        }

        long kk;
        kk = (long)kf;

        if (negate)
        {
            kk = -kk;
        }

        long kl;
        kl = -kd;

        long a;
        a = this.ValueComp(kk, kl);
        return a;
    }

    private long ValueComp(long cand, long expo)
    {
        long ka;
        ka = 1 << 50;
        ka = ka - 1;

        cand = cand & ka;

        long kb;
        kb = 1 << 10;
        kb = kb - 1;

        expo = expo & kb;

        long kc;
        kc = expo;
        kc = kc << 50;

        long k;
        k = 0;
        k = k | ka;
        k = k | kc;

        long a;
        a = k;
        return a;
    }

    private double InternValue(long value)
    {
        long ka;
        ka = value;
        ka = ka << 14;
        ka = ka >> 14;

        long kb;
        kb = value;
        kb = kb << 4;
        kb = kb >> 54;

        return this.InternValueComp(ka, kb);
    }

    private double InternValueComp(long cand, long expo)
    {
        double ka;
        ka = cand;
        double kb;
        kb = expo;

        double kc;
        kc = SystemMath.Pow(2, kb);

        double k;
        k = ka;
        k = k * kc;

        double a;
        a = k;
        return a;
    }

    private double InternValueTenComp(long cand, long expo)
    {
        double ka;
        ka = cand;
        double kb;
        kb = expo;

        double kc;
        kc = SystemMath.Pow(10, kb);

        double k;
        k = ka;
        k = k * kc;

        double a;
        a = k;
        return a;
    }

    private bool ValidIntern(double k)
    {
        return !(double.IsInfinity(k) | double.IsNaN(k));
    }
}