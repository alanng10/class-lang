namespace Avalon.List;

class Comparer : InternComparer
{
    public virtual Compare CompareAny { get; set; }

    public override int Compare(object x, object y)
    {
        return this.CompareAny.Execute(x, y);
    }
}