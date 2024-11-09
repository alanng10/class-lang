class Event : Any
{
    maide private Bool PrivateElapse()
    {
        this.Elapse();
        return true;
    }

    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        
        var Int ka;
        ka : this.InternIntern.StateTimeEventElapse();
        var Int arg;
        arg : this.InternIntern.Memory(this);
        this.InternElapseState : this.InternInfra.StateCreate(ka, arg);
        
        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.TimeEvent_New();
        extern.TimeEvent_Init(this.Intern);
        extern.TimeEvent_ElapseStateSet(this.Intern, this.InternElapseState);
        return true;
    }
    
    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.TimeEvent_Final(this.Intern);
        extern.TimeEvent_Delete(this.Intern);
        
        this.InternInfra.StateDelete(this.InternElapseState);
        return true;
    }
}