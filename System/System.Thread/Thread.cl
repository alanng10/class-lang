class Thread : Any
{
    maide private Int PrivateExecuteStateExecute()
    {
        this.ExecuteState.Execute();

        var Int a;
        a : cast Int(this.ExecuteState.Result);

        return a;
    }
    
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        var Int oa;
        oa : this.InternIntern.StateThreadExecute();
        var Int arg;
        arg : this.InternIntern.StateArgMemory(this);
        this.InternExecuteState : this.InternInfra.StateCreate(oa, arg);

        var Extern extern;
        extern : this.Extern;
        this.Intern : extern.Thread_New();
        extern.Thread_Init(this.Intern);
        extern.Thread_ExecuteStateSet(this.Intern, this.InternExecuteState);

        this.InternIntern.InitThread(this.Intern, this);
        return true;
    }

    maide prusate Bool InitMainThread()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        this.Intern : this.Extern.Thread_This();

        this.InternIntern.MainThreadSet(this);
        return true;
    }
    
    maide prusate Bool Final()
    {
        this.InternIntern.FinalThread(this.Intern);

        var Extern extern;
        extern : this.Extern;

        extern.Thread_Final(this.Intern);
        extern.Thread_Delete(this.Intern);

        this.InternInfra.StateDelete(this.InternExecuteState);
        return true;
    }

    field prusate State ExecuteState { get { return data; } set { data : value; } }
    field prusate Any Any { get { return data; } set { data : value; } }

    field prusate Int Status
    {
        get
        {
            var Int a;
            a : this.Extern.Thread_StatusGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field private Intern InternIntern { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    field private Int InternExecuteState { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        this.Extern.Thread_Execute(this.Intern);
        return true;
    }

    maide prusate Bool Wait()
    {
        this.Extern.Thread_Wait(this.Intern);
        return true;
    }

    maide prusate Int ExecuteMain()
    {
        var Int a;
        a : this.Extern.Thread_ExecuteMain(this.Intern);
        return a;
    }

    maide prusate Bool Exit(var Int status)
    {
        this.Extern.Thread_Exit(this.Intern, status);
        return true;
    }
}