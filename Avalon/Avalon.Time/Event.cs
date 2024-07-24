namespace Avalon.Time;

public class Event : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.TimeInfra = Infra.This;

        this.ElapseArg = new ElapseArg();
        this.ElapseArg.Init();
        this.ElapseArg.Event = this;
        this.Elapse = new EventEvent();
        this.Elapse.Init();

        this.InternHandle = new Handle();        
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress oa;
        oa = this.TimeInfra.IntervalElapseMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternElapseState = this.InternInfra.StateCreate(oa, arg);

        this.Intern = Extern.TimeEvent_New();
        Extern.TimeEvent_Init(this.Intern);
        Extern.TimeEvent_ElapseStateSet(this.Intern, this.InternElapseState);
        return true;
    }

    public virtual bool Final()
    {
        Extern.TimeEvent_Final(this.Intern);
        Extern.TimeEvent_Delete(this.Intern);

        this.InternInfra.StateDelete(this.InternElapseState);

        this.InternHandle.Final();
        return true;
    }

    public virtual EventEvent Elapse { get; set; }
    protected virtual ElapseArg ElapseArg { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra TimeInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternElapseState { get; set; }
    private Handle InternHandle { get; set; }

    public virtual long Time
    {
        get
        {
            ulong u;
            u = Extern.TimeEvent_TimeGet(this.Intern);
            long o;
            o = (long)u;
            return o;
        }
        set
        {
            ulong u;
            u = (ulong)value;
            Extern.TimeEvent_TimeSet(this.Intern, u);
        }
    }

    public virtual bool Single
    {
        get
        {
            ulong u;
            u = Extern.TimeEvent_SingleGet(this.Intern);
            bool b;
            b = (!(u == 0));
            return b;
        }
        set
        {
            ulong u;
            u = (ulong)(value ? 1 : 0);
            Extern.TimeEvent_SingleSet(this.Intern, u);
        }
    }

    public virtual bool Start()
    {
        Extern.TimeEvent_Start(this.Intern);
        return true;
    }

    public virtual bool Stop()
    {
        Extern.TimeEvent_Stop(this.Intern);
        return true;
    }

    protected virtual bool ExecuteElapse()
    {
        this.Elapse.Execute(this.ElapseArg);
        return true;
    }

    internal static ulong InternElapse(ulong interval, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Event a;
        a = (Event)ao;
        a.ExecuteElapse();

        return 1;
    }
}