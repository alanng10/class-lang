namespace Avalon.Math;

partial class Math
{
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