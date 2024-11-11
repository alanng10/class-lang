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

    maide prusate Bool Wait()
    {
        this.Extern.Program_Wait(this.Intern);
        return true;
    }

    maide prusate Bool Terminate()
    {
        this.Extern.Program_Terminate(this.Intern);
        return true;
    }

    maide prusate Bool Execute()
    {
        var Int nameU;
        nameU : this.InternInfra.StringCreate(this.Name);
        var Int argueU;
        argueU : this.InternStringListCreate(this.Argue);

        var Int workFoldU;
        workFoldU : 0;
        var Bool ba;
        ba : ~(this.WorkFold = null);
        inf (ba)
        {
            workFoldU : this.InternInfra.StringCreate(this.WorkFold);
        }

        var Int environU;
        environU : 0;
        var Bool bb;
        bb : ~(this.Environ = null);
        inf (bb)
        {
            environU : this.InternStringEntryListCreate(this.Environ);
        }

        var Extern extern;
        extern : this.Extern;

        extern.Program_NameSet(this.Intern, nameU);
        extern.Program_ArgueSet(this.Intern, argueU);
        extern.Program_WorkFoldSet(this.Intern, workFoldU);
        extern.Program_EnvironSet(this.Intern, environU);

        extern.Program_Execute(this.Intern);
        
        extern.Program_EnvironSet(this.Intern, 0);
        extern.Program_WorkFoldSet(this.Intern, 0);
        extern.Program_ArgueSet(this.Intern, 0);
        extern.Program_NameSet(this.Intern, 0);       

        inf (bb)
        {
            this.InternStringEntryListDelete(environU);
        }
        inf (ba)
        {
            this.InternInfra.StringDelete(workFoldU);
        }

        this.InternStringListDelete(argueU);

        this.InternInfra.StringDelete(nameU);
        return true;
    }
}