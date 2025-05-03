namespace Avalon.Thread;

public class Phore : Any
{
    public override bool Init()
    {
        base.Init();
        
        int k;
        k = (int)this.InitCount;

        this.Intern = new SystemPhore(k);
        return true;
    }

    public virtual bool Final()
    {
        this.Intern.Dispose();
        return true;
    }

    public virtual long InitCount { get; set; }
    public virtual long Count
    {
        get
        {
            long a;
            a = this.Intern.CurrentCount;
            return a;
        }
        set
        {
        }
    }
    private SystemPhore Intern { get; set; }

    public virtual bool Open()
    {
        this.Intern.Wait();
        return true;
    }

    public virtual bool Close()
    {
        this.Intern.Release();
        return true;
    }
}