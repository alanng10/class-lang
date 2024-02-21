namespace Avalon.Infra;

public class RefCompare : Compare
{
    public override bool Init()
    {
        base.Init();
        this.Comparer = ReferenceEqualityComparer.Instance;
        return true;
    }

    protected virtual ReferenceEqualityComparer Comparer { get; set; }

    public override int Execute(object left, object right)
    {
        if (left == null)
        {
            return 0;
        }
        if (right == null)
        {
            return 0;
        }

        int lu;
        lu = this.Comparer.GetHashCode(left);
        int ru;
        ru = this.Comparer.GetHashCode(right);
        int k;
        k = lu.CompareTo(ru);
        return k;
    }
}