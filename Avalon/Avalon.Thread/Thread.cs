namespace Avalon.Thread;

public class Thread : Any
{
    private ulong PrivateExecuteStateExecute()
    {
        this.ExecuteState.Execute();

        object aa;
        aa = this.ExecuteState.Result;

        ulong oa;
        oa = 0;

        if (!(aa == null))
        {
            if (aa is Value)
            {
                Value k;
                k = (Value)aa;

                long o;
                o = k.Int;

                oa = (ulong)o;
            }
        }

        return oa;
    }

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
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.ThreadInfra = Infra.This;

        this.Intern = Extern.Thread_This();

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

    public virtual State ExecuteState { get; set; }
    public virtual object Any { get; set; }
    public virtual long Status
    {
        get
        {
            ulong u;
            u = Extern.Thread_StatusGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }
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

        ulong oa;
        oa = a.PrivateExecuteStateExecute();

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

    public virtual long ExecuteMain()
    {
        ulong u;
        u = Extern.Thread_ExecuteMain(this.Intern);
        long a;
        a = (long)u;
        return a;
    }

    public virtual bool Exit(long status)
    {
        ulong u;
        u = (ulong)status;

        Extern.Thread_Exit(this.Intern, u);
        return true;
    }
}