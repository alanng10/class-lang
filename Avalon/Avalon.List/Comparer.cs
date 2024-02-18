namespace Avalon.List;




class Comparer : Any, IComparerObject
{
    public virtual Compare CompareAny { get; set; }



    public int Compare(object x, object y)
    {
        return this.CompareAny.Execute(x, y);
    }
}