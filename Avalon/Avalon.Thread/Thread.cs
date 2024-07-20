namespace Avalon.Thread;

public class Thread : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.ThreadInfra = Infra.This;
        this.InternHandle = new Handle();
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress oa;
        oa = this.ThreadInfra.ThreadExecuteMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternExecuteState = this.InternInfra.StateCreate(oa, arg);

        this.Intern = Extern.Thread_New();
        Extern.Thread_Init(this.Intern);
        Extern.Thread_ExecuteStateSet(this.Intern, this.InternExecuteState);
        return true;
    }

    public virtual bool InitMainThread()
    {
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.ThreadInfra = Infra.This;

        this.Intern = Extern.Thread_CurrentThread();

        InternIntern.ThisThread = this;
        return true;
    }

    public virtual bool Final()
    {
        Extern.Thread_Final(this.Intern);
        Extern.Thread_Delete(this.Intern);

        this.InternInfra.StateDelete(this.InternExecuteState);

        this.InternHandle.Final();
        
        return true;
    }

    public virtual ExecuteState ExecuteState { get; set; }
    public virtual object Any { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra ThreadInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternExecuteState { get; set; }
    private Handle InternHandle { get; set; }

    internal static ulong InternExecute(ulong thread, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Thread a;        
        a = (Thread)ao;

        InternIntern.ThisThread = a;

        a.ExecuteState.Execute();

        int o;
        o = a.ExecuteState.Result;

        ulong oa;
        oa = (ulong)o;
        return oa;
    }

    public virtual bool Execute()
    {
        Extern.Thread_Execute(this.Intern);
        return true;
    }

    public virtual bool Wait()
    {
        Extern.Thread_Wait(this.Intern);
        return true;
    }

    public virtual int ExecuteEventLoop()
    {
        ulong u;
        u = Extern.Thread_ExecuteEventLoop(this.Intern);
        int a;
        a = (int)u;
        return a;
    }

    public virtual bool ExitEventLoop(int code)
    {
        ulong u;
        u = (ulong)code;

        Extern.Thread_ExitEventLoop(this.Intern, u);
        return true;
    }

    public virtual bool Main
    {
        get
        {
            ulong u;
            u = Extern.Thread_IsMainThread(this.Intern);
            bool a;
            a = (!(u == 0));
            return a;
        }
        set
        {
        }
    }

    public virtual long Ident
    {
        get
        {
            ulong u;
            u = Extern.Thread_IdentGet(this.Intern);
            long o;
            o = (long)u;
            return o;
        }
        set
        {
            ulong u;
            u = (ulong)value;
            Extern.Thread_IdentSet(this.Intern, u);
        }
    }

    public virtual int Status
    {
        get
        {
            ulong u;
            u = Extern.Thread_StatusGet(this.Intern);
            int o;
            o = (int)u;
            return o;
        }
        set
        {
        }
    }
}