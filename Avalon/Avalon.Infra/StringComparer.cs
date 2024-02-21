namespace Avalon.Infra;

public class StringComparer : Any, IComparerObject
{
    public override bool Init()
    {
        base.Init();
        this.StringCompare = new StringCompare();
        this.StringCompare.Init();
        return true;
    }

    private StringCompare StringCompare { get; set; }

    public int Compare(object x, object y)
    {
        return this.StringCompare.Execute(x, y);
    }
}