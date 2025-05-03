namespace Avalon.Math;

public class Rand : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.SeedSet(0);
        return true;
    }

    public virtual long Seed { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    private SystemRand Intern { get; set; }

    public virtual bool SeedSet(long value)
    {
        int k;
        k = (int)value;
        this.Intern = new SystemRand(k);
        return true;
    }

    public virtual long Execute()
    {
        long a;
        a = this.Intern.NextInt64(this.InfraInfra.IntCapValue);
        return a;
    }
}