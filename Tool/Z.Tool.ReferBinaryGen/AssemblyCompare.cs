namespace Z.Tool.ReferBinaryGen;

class AssemblyCompare : Compare
{
    public override bool Init()
    {
        base.Init();
        this.Compare = new StringCompare();
        this.Compare.Init();
        return true;
    }

    protected virtual StringCompare Compare { get; set; }

    public override int Execute(object left, object right)
    {
        if (left == null | right == null)
        {
            return 0;
        }

        Assembly oa;
        oa = (Assembly)left;
        Assembly ob;
        ob = (Assembly)right;
        return this.Compare.Execute(oa.FullName, ob.FullName);
    }
}