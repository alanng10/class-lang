namespace Class.Infra;

public class ModuleRefCompare : Compare
{
    public override bool Init()
    {
        base.Init();

        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();

        this.StringCompare = new StringCompare();
        this.StringCompare.CharCompare = charCompare;
        this.StringCompare.Init();

        this.LongCompare = new LongCompare();
        this.LongCompare.Init();
        return true;
    }

    protected virtual StringCompare StringCompare { get; set; }
    protected virtual LongCompare LongCompare { get; set; }

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

        return this.LongCompare.Execute(leftA.Version, rightA.Version);
    }
}