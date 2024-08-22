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

    public override long Execute(object left, object right)
    {
        ModuleRef leftA;
        ModuleRef rightA;
        leftA = (ModuleRef)left;
        rightA = (ModuleRef)right;

        long a;
        a = this.StringLess.Execute(leftA.Name, rightA.Name);

        if (!(a == 0))
        {
            return a;
        }

        return this.LessInt.Execute(leftA.Version, rightA.Version);
    }
}