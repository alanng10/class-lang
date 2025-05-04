namespace Avalon.Time;

public class Event : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = new SystemTimeEvent();
        this.Intern.AutoReset = true;
        this.Intern.Elapsed += this.ElapseHandle;
        return true;
    }

    public virtual bool Final()
    {
        this.Intern.Dispose();
        return true;
    }

    public virtual long Time
    {
        get
        {
            long a;
            a = (long)this.Intern.Interval;
            return a;
        }
        set
        {
            double k;
            k = value;
            this.Intern.Interval = k;
        }
    }
    private SystemTimeEvent Intern { get; set; }

    public virtual bool Start()
    {
        this.Intern.Start();
        return true;
    }

    public virtual bool Stop()
    {
        this.Intern.Stop();
        return true;
    }

    public virtual bool Elapse()
    {
        return false;
    }

    public virtual bool Wait(long time)
    {
        int k;
        k = (int)time;

        SystemThread.Sleep(k);

        return true;
    }

    private void ElapseHandle(object sender, SystemTimeEventHandleArg e)
    {
        this.Elapse();
    }
}