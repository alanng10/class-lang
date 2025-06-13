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
        arg : this.InternIntern.StateArgMemory(this);
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

    field prusate Int Time
    {
        get
        {
            var Int a;
            a : this.Extern.TimeEvent_TimeGet(this.Intern);
            return a;
        }
        set
        {
            this.Extern.TimeEvent_TimeSet(this.Intern, value);   
        }
    }
    field private Intern InternIntern { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    field private Int InternElapseState { get { return data; } set { data : value; } }

    maide prusate Bool Start()
    {
        this.Extern.TimeEvent_Start(this.Intern);
        return true;
    }
    
    maide prusate Bool Stop()
    {
        this.Extern.TimeEvent_Stop(this.Intern);
        return true;
    }
    
    maide prusate Bool Elapse()
    {
    }

    maide prusate Bool Wait(var Int time)
    {
        this.Extern.TimeEvent_Wait(time);
        return true;
    }
}