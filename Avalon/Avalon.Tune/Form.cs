namespace Avalon.Tune;

public class Form : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;

        // this.Intern = Extern.TuneForm_New();
        // Extern.TuneForm_Init(this.Intern);
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    internal virtual ulong Intern { get; set; }

    public virtual bool Final()
    {
        // Extern.TuneForm_Final(this.Intern);
        // Extern.TuneForm_Delete(this.Intern);
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
        u = 0;
        // u = Extern.TuneForm_ValueGet(this.Intern, r, c);
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
        k = 0;
        // k = Extern.TuneForm_ValueSet(this.Intern, r, c, u);

        if (k == 0)
        {
            return false;
        }
        return true;
    }

    public virtual bool Reset()
    {
        // Extern.TuneForm_Reset(this.Intern);
        return true;
    }

    public virtual bool IsIdentity()
    {
        ulong u;
        u = 0;
        // u = Extern.TuneForm_IsIdentity(this.Intern);
        
        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool Pos(long value)
    {
        ulong valueU;
        valueU = (ulong)value;
        
        ulong u;
        u = 0;
        //u = Extern.TuneForm_Pos(this.Intern, valueU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool Time(long value)
    {
        ulong valueU;
        valueU = (ulong)value;

        ulong u;
        u = 0;
        //u = Extern.TuneForm_Time(this.Intern, valueU);

        bool a;
        a = !(u == 0);
        return a;
    }

    public virtual bool Mul(Form other)
    {
        // Extern.TuneForm_Mul(this.Intern, other.Intern);
        return true;
    }

    public virtual bool ValidRow(long index)
    {
        return this.InfraInfra.ValidIndex(2, index);
    }

    public virtual bool ValidCol(long index)
    {
        return this.InfraInfra.ValidIndex(2, index);
    }
}