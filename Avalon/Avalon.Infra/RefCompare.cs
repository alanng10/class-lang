namespace Avalon.Infra;

public class RefCompare : Compare
{
    public override bool Init()
    {
        base.Init();
        this.Comparer = ReferenceEqualityComparer.Instance;
        return true;
    }

    private ReferenceEqualityComparer Comparer { get; set; }

    public override int Execute(object left, object right)
    {
        if (left == null | right == null)
        {
            return 0;
        }

        int lu;
        int ru;
        lu = this.Comparer.GetHashCode(left);
        ru = this.Comparer.GetHashCode(right);
        int k;
        k = lu.CompareTo(ru);
        return k;
    }
}