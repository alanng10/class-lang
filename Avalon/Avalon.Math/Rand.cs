namespace Avalon.Math;

public class Rand : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.Random_New();
        Extern.Random_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Random_Final(this.Intern);
        Extern.Random_Delete(this.Intern);
        return true;
    }

    private ulong Intern { get; set; }

    public virtual long Seed
    {
        get
        {
            ulong u;
            u = Extern.Random_SeedGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
            ulong u;
            u = (ulong)value;
            Extern.Random_SeedSet(this.Intern, u);
        }
    }
    protected long __D_Seed;

    public virtual long Execute()
    {
        ulong u;
        u = Extern.Random_Execute(this.Intern);
        long a;
        a = (long)u;
        return a;
    }
}