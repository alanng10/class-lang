namespace Avalon.Math;

partial class Math
{
    public virtual long Add(long valueA, long valueB)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)valueA;
        ub = (ulong)valueB;
        ulong u;
        u = Extern.Math_Add(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Sub(long valueA, long valueB)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)valueA;
        ub = (ulong)valueB;
        ulong u;
        u = Extern.Math_Sub(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Mul(long valueA, long valueB)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)valueA;
        ub = (ulong)valueB;
        ulong u;
        u = Extern.Math_Mul(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Div(long valueA, long valueB)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)valueA;
        ub = (ulong)valueB;
        ulong u;
        u = Extern.Math_Div(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Abs(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Abs(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Exp(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Exp(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Exp2(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Exp2(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Log(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Log(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Log10(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Log10(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Log2(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Log2(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Pow(long valueA, long valueB)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)valueA;
        ub = (ulong)valueB;
        ulong u;
        u = Extern.Math_Pow(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Sqrt(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Sqrt(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Cbrt(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Cbrt(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Ceil(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Ceil(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Floor(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Floor(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Trunc(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Trunc(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Round(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Round(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ATan2(long valueA, long valueB)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)valueA;
        ub = (ulong)valueB;
        ulong u;
        u = Extern.Math_ATan2(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Sin(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Sin(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Cos(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Cos(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Tan(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Tan(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ASin(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ASin(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ACos(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ACos(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ATan(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ATan(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long SinH(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_SinH(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long CosH(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_CosH(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long TanH(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_TanH(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ASinH(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ASinH(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ACosH(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ACosH(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ATanH(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ATanH(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }
}