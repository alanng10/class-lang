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

    public virtual long ValueGet(long col, long row)
    {
        if (!this.ValidCol(col))
        {
            return -1;
        }
        if (!this.ValidRow(row))
        {
            return -1;
        }

        ulong c;
        ulong r;
        c = (ulong)col;
        r = (ulong)row;
        ulong k;
        k = Extern.Form_ValueGet(this.Intern, c, r);
        long a;
        a = (long)k;
        return a;
    }

    public virtual bool ValueSet(long col, long row, long value)
    {
        if (!this.ValidCol(col))
        {
            return false;
        }
        if (!this.ValidRow(row))
        {
            return false;
        }

        ulong c;
        ulong r;
        c = (ulong)col;
        r = (ulong)row;
        ulong u;
        u = (ulong)value;

        ulong k;
        k = Extern.Form_ValueSet(this.Intern, c, r, u);

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

    public virtual bool Scale(long col, long row)
    {
        ulong c;
        ulong r;
        c = (ulong)col;
        r = (ulong)row;

        ulong k;
        k = Extern.Form_Scale(this.Intern, c, r);

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