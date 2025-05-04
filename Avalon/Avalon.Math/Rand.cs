namespace Avalon.Math;

public class Rand : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.Rand_New();
        Extern.Rand_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Rand_Final(this.Intern);
        Extern.Rand_Delete(this.Intern);
        return true;
    }

    private ulong Intern { get; set; }

    public virtual long Seed
    {
        get
        {
            ulong u;
            u = Extern.Rand_SeedGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
            ulong u;
            u = (ulong)value;
            Extern.Rand_SeedSet(this.Intern, u);
        }
    }

    public virtual long Execute()
    {
        ulong u;
        u = Extern.Rand_Execute(this.Intern);
        long a;
        a = (long)u;
        return a;
    }
}