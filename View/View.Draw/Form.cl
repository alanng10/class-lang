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

    maide prusate Int ValueGet(var Int row, var Int col)
    {
        
    }
}