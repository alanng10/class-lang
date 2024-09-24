namespace Avalon.Draw;

public class Form : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;

        this.Intern = Extern.Form_New();
        Extern.Form_Init(this.Intern);
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    internal virtual ulong Intern { get; set; }

    public virtual bool Final()
    {
        Extern.Form_Final(this.Intern);
        Extern.Form_Delete(this.Intern);
        return true;
    }

    public virtual long ValueGet(long row, long col)
    {
        if (!this.ValidRow(row))
        {
            return -1;
        }
        if (!this.ValidCol(col))
        {
            return -1;
        }

        ulong r;
        ulong c;
        r = (ulong)row;
        c = (ulong)col;
        ulong u;
        u = Extern.Form_ValueGet(this.Intern, r, c);
        long a;
        a = (long)u;
        return a;
    }

    public virtual bool ValueSet(long row, long col, long value)
    {
        if (!this.ValidRow(row))
        {
            return false;
        }
        if (!this.ValidCol(col))
        {
            return false;
        }

        ulong r;
        ulong c;
        r = (ulong)row;
        c = (ulong)col;
        ulong u;
        u = (ulong)value;

        ulong k;
        k = Extern.Form_ValueSet(this.Intern, r, c, u);

        if (k == 0)
        {
            return false;
        }
        return true;
    }

    public virtual bool Reset()
    {
        Extern.Form_Reset(this.Intern);
        return true;
    }

    public virtual bool IsIdentity()
    {
        ulong u;
        u = Extern.Form_IsIdentity(this.Intern);
        
        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool Pos(long col, long row, long hor)
    {
        ulong colU;
        ulong rowU;
        ulong horU;
        colU = (ulong)col;
        rowU = (ulong)row;
        horU = (ulong)hor;
        
        ulong u;
        u = 0;
        //u = Extern.Form_Offset(this.Intern, colU, rowU, horU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool Angle(long col, long row, long hor)
    {
        ulong colU;
        ulong rowU;
        ulong horU;
        colU = (ulong)col;
        rowU = (ulong)row;
        horU = (ulong)hor;

        ulong u;
        u = 0;
        //u = Extern.Form_Rotate(this.Intern, colU, rowU, horU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool Time(long col, long row, long hor)
    {
        ulong colU;
        ulong rowU;
        ulong horU;
        colU = (ulong)col;
        rowU = (ulong)row;
        horU = (ulong)hor;

        ulong u;
        u = 0;
        //u = Extern.Form_Scale(this.Intern, colU, rowU, horU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool Mul(Form other)
    {
        Extern.Form_Multiply(this.Intern, other.Intern);
        return true;
    }

    public virtual bool ValidRow(long index)
    {
        return this.InfraInfra.ValidIndex(4, index);
    }

    public virtual bool ValidCol(long index)
    {
        return this.InfraInfra.ValidIndex(4, index);
    }
}