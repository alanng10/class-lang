class Form : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InfraInfra : share InfraInfra;

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.Form_New();
        extern.Form_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Form_Final(this.Intern);
        extern.Form_Delete(this.Intern);
        return true;
    }

    field prusate Bool Ident
    {
        get
        {
            var Int k;
            k : this.Extern.Form_Ident(this.Intern);

            var Bool a;
            a : ~(k = 0);
            return a;
        }
        set
        {
        }
    }

    field private Extern Extern { get { return data; } set { data : value; } }
    field precate InfaInfra InfraInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }

    maide prusate Int ValueGet(var Int col, var Int row)
    {
        inf (~this.ValidCol(col))
        {
            return null;
        }
        inf (~this.ValidRow(row))
        {
            return null;
        }

        var Int a;
        a : this.Extern.Form_ValueGet(this.Intern, col, row);
        return a;
    }

    maide prusate Bool ValueSet(var Int col, var Int row, var Int value)
    {
        inf (~this.ValidCol(col))
        {
            return null;
        }
        inf (~this.ValidRow(row))
        {
            return null;
        }

        var Int k;
        k : this.Extern.Form_ValueSet(this.Intern, col, row, value);

        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool Reset()
    {
        this.Extern.Form_Reset(this.Intern);
        return true;
    }

    maide prusate Bool Pos(var Int col, var Int row)
    {
        var Int k;
        k : this.Extern.Form_Pos(this.Intern, col, row);

        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool Angle(var Int angle)
    {
        var Int k;
        k : this.Extern.Form_Angle(this.Intern, angle);

        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool Scale(var Int col, var Int row)
    {
        var Int k;
        k : this.Extern.Form_Scale(this.Intern, col, row);

        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool Mul(var Form other)
    {
        this.Extern.Form_Mul(this.Intern, other.Intern);
        return true;
    }

    maide prusate Bool ValidCol(var Int index)
    {
        return this.InfraInfra.ValidIndex(3, index);
    }

    maide prusate Bool ValidRow(var Int index)
    {
        return this.InfraInfra.ValidIndex(3, index);
    }
}