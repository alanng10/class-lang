namespace Class.Node;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();

        Any a;
        a = share;
        a.Init();

        return share;
    }


    public override bool Init()
    {
        base.Init();

        this.InfraInfra = InfraInfra.This;        

        this.IntSignValueNegativeMax = this.InfraInfra.IntCapValue / 2;

        this.IntSignValuePositiveMax = this.IntSignValueNegativeMax - 1;

        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public virtual long IntSignValuePositiveMax { get; set; }

    public virtual long IntSignValueNegativeMax { get; set; }
}