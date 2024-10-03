namespace Mirai.Infra;

public class Comp : CompComp
{
    public override bool Init()
    {
        base.Init();
        this.CompInfra = Infra.This;
        return true;
    }

    protected virtual Infra CompInfra { get; set; }
}