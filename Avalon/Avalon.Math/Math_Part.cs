namespace Avalon.Math;

partial class Math
{
    public virtual long Add(long valueA, long valueB)
    {
        double ka;
        double kb;
        ka = this.InternValue(valueA);
        kb = this.InternValue(valueB);
        if (!(this.ValidIntern(ka) & this.ValidIntern(kb)))
        {
            return -1;
        }

        double kc;
        kc = ka + kb;

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Sub(long valueA, long valueB)
    {
        double ka;
        double kb;
        ka = this.InternValue(valueA);
        kb = this.InternValue(valueB);
        if (!(this.ValidIntern(ka) & this.ValidIntern(kb)))
        {
            return -1;
        }

        double kc;
        kc = ka - kb;

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Mul(long valueA, long valueB)
    {
        double ka;
        double kb;
        ka = this.InternValue(valueA);
        kb = this.InternValue(valueB);
        if (!(this.ValidIntern(ka) & this.ValidIntern(kb)))
        {
            return -1;
        }

        double kc;
        kc = ka * kb;

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Div(long valueA, long valueB)
    {
        double ka;
        double kb;
        ka = this.InternValue(valueA);
        kb = this.InternValue(valueB);
        if (!(this.ValidIntern(ka) & this.ValidIntern(kb)))
        {
            return -1;
        }

        double kc;
        kc = ka / kb;

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Abs(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Abs(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Exp(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Exp(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Log(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Log(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Log10(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Log10(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Log2(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Log2(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Pow(long valueA, long valueB)
    {
        double ka;
        double kb;
        ka = this.InternValue(valueA);
        kb = this.InternValue(valueB);
        if (!(this.ValidIntern(ka) & this.ValidIntern(kb)))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Pow(ka, kb);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Ceil(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Ceiling(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Floor(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Floor(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Trunc(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Truncate(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Round(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Round(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Sin(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Sin(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Cos(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Cos(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long Tan(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Tan(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long ASin(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Asin(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long ACos(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Acos(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long ATan(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Atan(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long SinH(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Sinh(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long CosH(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Cosh(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long TanH(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Tanh(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long ASinH(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Asinh(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long ACosH(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Acosh(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }

    public virtual long ATanH(long value)
    {
        double ka;
        ka = this.InternValue(value);
        if (!this.ValidIntern(ka))
        {
            return -1;
        }

        double kc;
        kc = SystemMath.Atanh(ka);

        long a;
        a = this.ValueInternValue(kc);
        return a;
    }
}