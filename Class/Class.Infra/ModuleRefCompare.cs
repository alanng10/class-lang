namespace Class.Infra;

public class ModuleRefCompare : Compare
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;

        this.StringCompare = this.InfraInfra.StringCompareCreate();

        this.CompareInt = new CompareInt();
        this.CompareInt.Init();
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StringCompare StringCompare { get; set; }
    protected virtual CompareInt CompareInt { get; set; }

    public override long Execute(object left, object right)
    {
        ModuleRef leftA;
        ModuleRef rightA;
        leftA = (ModuleRef)left;
        rightA = (ModuleRef)right;

        long a;
        a = this.StringCompare.Execute(leftA.Name, rightA.Name);

        if (!(a == 0))
        {
            return a;
        }

        return this.CompareInt.Execute(leftA.Version, rightA.Version);
    }
}