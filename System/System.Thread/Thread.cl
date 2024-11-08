class Thread : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        
        var Int oa;
        oa : this.InternIntern.StateThreadExecute();
        var Int arg;
        arg : this.InternIntern.Memory(this);
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
}