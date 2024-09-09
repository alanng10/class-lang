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

    public override long Execute(object lite, object rite)
    {
        if (lite == null | rite == null)
        {
            return 0;
        }

        ReferenceEqualityComparer comparer;
        comparer = this.Comparer;

        long lu;
        long ru;
        lu = comparer.GetHashCode(lite);
        ru = comparer.GetHashCode(rite);
        long a;
        a = lu - ru;
        return a;
    }
}