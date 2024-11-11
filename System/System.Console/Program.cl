class Program : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.Program_New();
        extern.Program_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Program_Final(this.Intern);
        extern.Program_Delete(this.Intern);
        return true;
    }

    field prusate String Name { get { return data; } set { data : value; } }
    field prusate List Argue { get { return data; } set { data : value; } }
    field prusate String WorkFold { get { return data; } set { data : value; } }
    field prusate Table Environ { get { return data; } set { data : value; } }
    field prusate Int Ident
    {
        get
        {
            var Int a;
            a : this.Extern.Program_IdentGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int Status
    {
        get
        {
            var Int a;
            a : this.Extern.Program_StatusGet(this.Intern);
            return a;
        }
        set
        {
        }
    }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
}