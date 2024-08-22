namespace Class.Infra;

public class ModuleRefLess : Less
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;

        this.StringLess = this.InfraInfra.StringLessCreate();

        this.LessInt = new LessInt();
        this.LessInt.Init();
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StringLess StringLess { get; set; }
    protected virtual LessInt LessInt { get; set; }

    public override long Execute(object lite, object rite)
    {
        ModuleRef liteA;
        ModuleRef riteA;
        liteA = (ModuleRef)lite;
        riteA = (ModuleRef)rite;

        long a;
        a = this.StringLess.Execute(liteA.Name, riteA.Name);

        if (!(a == 0))
        {
            return a;
        }

        return this.LessInt.Execute(liteA.Version, riteA.Version);
    }
}