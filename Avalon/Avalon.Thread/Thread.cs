namespace Avalon.Thread;

public class Thread : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.Intern = new SystemThread(this.InternExecute);
        return true;
    }

    public virtual bool InitMainThread()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        InternIntern.ThisThread = this;
        return true;
    }

    public virtual bool Final()
    {
        return true;
    }

    public virtual State ExecuteState { get; set; }
    public virtual object Any { get; set; }
    private InternIntern InternIntern { get; set; }
    private SystemThread Intern { get; set; }

    private void InternExecute()
    {
        this.PrivateExecuteStateExecute();
    }

    private bool PrivateExecuteStateExecute()
    {
        InternIntern.ThisThread = this;

        this.ExecuteState.Execute();
        return true;
    }

    public virtual bool Execute()
    {
        this.Intern.Start();
        return true;
    }

    public virtual bool Wait()
    {
        this.Intern.Join();
        return true;
    }
}