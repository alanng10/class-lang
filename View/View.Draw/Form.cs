namespace View.Draw;

public class Form : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;

        this.Intern = Extern.Form_New();
        Extern.Form_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Form_Final(this.Intern);
        Extern.Form_Delete(this.Intern);
        return true;
    }


    public virtual bool Ident
    {
        get
        {
            ulong k;
            k = Extern.Form_Ident(this.Intern);
    
            bool a;
            a = !(k == 0);
            return a;
        }
        set
        {
        }
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    internal virtual ulong Intern { get; set; }

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
        ulong k;
        k = Extern.Form_ValueGet(this.Intern, r, c);
        long a;
        a = (long)k;
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

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool Reset()
    {
        Extern.Form_Reset(this.Intern);
        return true;
    }

    public virtual bool Pos(long col, long row)
    {
        ulong colU;
        ulong rowU;
        colU = (ulong)col;
        rowU = (ulong)row;

        ulong k;
        k = Extern.Form_Pos(this.Intern, colU, rowU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool Angle(long angle)
    {
        ulong angleU;
        angleU = (ulong)angle;

        ulong k;
        k = Extern.Form_Angle(this.Intern, angleU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool Scale(long horizScale, long vertScale)
    {
        ulong horizScaleU;
        ulong vertScaleU;
        horizScaleU = (ulong)horizScale;
        vertScaleU = (ulong)vertScale;

        ulong k;
        k = Extern.Form_Scale(this.Intern, horizScaleU, vertScaleU);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool Mul(Form other)
    {
        Extern.Form_Mul(this.Intern, other.Intern);
        return true;
    }

    public virtual bool ValidRow(long index)
    {
        return this.InfraInfra.ValidIndex(3, index);
    }

    public virtual bool ValidCol(long index)
    {
        return this.InfraInfra.ValidIndex(3, index);
    }
}