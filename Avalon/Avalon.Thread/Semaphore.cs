namespace Avalon.Thread;

public class Semaphore : Any
{
    public override bool Init()
    {
        base.Init();
        ulong ua;
        ua = (ulong)(this.InitCount);
        this.Intern = Extern.Semaphore_New();
        Extern.Semaphore_InitCountSet(this.Intern, ua);
        Extern.Semaphore_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Semaphore_Final(this.Intern);
        Extern.Semaphore_Delete(this.Intern);
        return true;
    }

    public virtual int InitCount { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Acquire()
    {
        Extern.Semaphore_Acquire(this.Intern);
        return true;
    }

    public virtual bool Release()
    {
        Extern.Semaphore_Release(this.Intern);
        return true;
    }

    public virtual int Count
    {
        get
        {
            ulong u;
            u = Extern.Semaphore_CountGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }
}