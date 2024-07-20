namespace Avalon.Intern;

public class Comparer : IComparerObject
{
    public virtual bool Init()
    {
        return true;
    }

    public virtual int Compare(object x, object y)
    {
        return 0;
    }
}