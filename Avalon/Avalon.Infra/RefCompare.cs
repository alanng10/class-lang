namespace Avalon.Infra;

public class RefLess : Less
{
    public override bool Init()
    {
        base.Init();
        this.Comparer = ReferenceEqualityComparer.Instance;
        return true;
    }

    private ReferenceEqualityComparer Comparer { get; set; }

    public override long Execute(object left, object right)
    {
        if (left == null | right == null)
        {
            return 0;
        }

        ReferenceEqualityComparer comparer;
        comparer = this.Comparer;

        long lu;
        long ru;
        lu = comparer.GetHashCode(left);
        ru = comparer.GetHashCode(right);
        long a;
        a = lu - ru;
        return a;
    }
}