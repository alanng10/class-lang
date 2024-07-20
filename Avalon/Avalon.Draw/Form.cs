namespace Avalon.Draw;

public class Form : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.Intern = Extern.Transform_New();
        Extern.Transform_Init(this.Intern);
        return true;
    }

    private InternIntern InternIntern { get; set; }
    internal virtual ulong Intern { get; set; }

    public virtual bool Final()
    {
        Extern.Transform_Final(this.Intern);
        Extern.Transform_Delete(this.Intern);
        return true;
    }

    public virtual long ValueGet(int row, int col)
    {
        ulong r;
        ulong c;
        r = (ulong)row;
        c = (ulong)col;
        ulong u;
        u = Extern.Transform_ValueGet(this.Intern, r, c);
        long a;
        a = (long)u;
        return a;
    }

    public virtual bool ValueSet(int row, int col, long value)
    {
        ulong r;
        ulong c;
        r = (ulong)row;
        c = (ulong)col;
        ulong u;
        u = (ulong)value;
        Extern.Transform_ValueSet(this.Intern, r, c, u);
        return true;
    }

    public virtual bool Reset()
    {
        Extern.Transform_Reset(this.Intern);
        return true;
    }

    public virtual bool IsIdentity()
    {
        ulong u;
        u = Extern.Transform_IsIdentity(this.Intern);
        bool b;
        b = (!(u == 0));
        return b;
    }

    public virtual bool Offset(long left, long up)
    {
        ulong leftU;
        ulong upU;
        leftU = (ulong)left;
        upU = (ulong)up;
        Extern.Transform_Offset(this.Intern, leftU, upU);
        return true;
    }

    public virtual bool Rotate(long angle)
    {
        ulong angleU;
        angleU = (ulong)angle;
        Extern.Transform_Rotate(this.Intern, angleU);
        return true;
    }

    public virtual bool Scale(long horizScale, long vertScale)
    {
        ulong horizScaleU;
        ulong vertScaleU;
        horizScaleU = (ulong)horizScale;
        vertScaleU = (ulong)vertScale;
        Extern.Transform_Scale(this.Intern, horizScaleU, vertScaleU);
        return true;
    }

    public virtual bool Multiply(Form other)
    {
        Extern.Transform_Multiply(this.Intern, other.Intern);
        return true;
    }
}