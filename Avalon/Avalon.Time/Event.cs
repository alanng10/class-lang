namespace Avalon.Time;

public class Event : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.TimeInfra = Infra.This;

        this.InternHandle = new Handle();        
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress oa;
        oa = this.TimeInfra.TimeEventElapseMaideAddress;
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

    public virtual State Elapse { get; set; }

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
        if (!(this.Elapse == null))
        {
            this.Elapse.Execute();
        }
        return true;
    }

    private bool PrivateElapse()
    {
        this.ExecuteElapse();
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
        a.PrivateElapse();

        return 1;
    }
}