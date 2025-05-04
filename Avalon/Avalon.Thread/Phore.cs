namespace Avalon.Thread;

public class Phore : Any
{
    public override bool Init()
    {
        base.Init();
        ulong ua;
        ua = (ulong)(this.InitCount);
        this.Intern = Extern.Phore_New();
        Extern.Phore_InitCountSet(this.Intern, ua);
        Extern.Phore_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Phore_Final(this.Intern);
        Extern.Phore_Delete(this.Intern);
        return true;
    }

    public virtual long InitCount { get; set; }
    public virtual long Count
    {
        get
        {
            ulong u;
            u = Extern.Phore_CountGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }
    private ulong Intern { get; set; }

    public virtual bool Open()
    {
        Extern.Phore_Open(this.Intern);
        return true;
    }

    public virtual bool Close()
    {
        Extern.Phore_Close(this.Intern);
        return true;
    }
}