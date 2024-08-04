namespace Class.Infra;

public class ModuleRefCompare : Compare
{
    public override bool Init()
    {
        base.Init();

        CompareMid charCompare;
        charCompare = new CompareMid();
        charCompare.Init();

        this.StringCompare = new StringCompare();
        this.StringCompare.CharCompare = charCompare;
        this.StringCompare.Init();

        this.CompareInt = new CompareInt();
        this.CompareInt.Init();
        return true;
    }

    protected virtual StringCompare StringCompare { get; set; }
    protected virtual CompareInt CompareInt { get; set; }

    public override int Execute(object left, object right)
    {
        if (left == null | right == null)
        {
            return 0;
        }

        ModuleRef leftA;
        ModuleRef rightA;
        leftA = (ModuleRef)left;
        rightA = (ModuleRef)right;

        int a;
        a = this.StringCompare.Execute(leftA.Name, rightA.Name);

        if (!(a == 0))
        {
            return a;
        }

        return this.CompareInt.Execute(leftA.Version, rightA.Version);
    }
}