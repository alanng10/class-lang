namespace Avalon.View;

public class ListIter : Iter
{
    internal virtual Iter Iter { get; set; }

    public override bool Next()
    {
        return this.Iter.Next();
    }

    public override object Index
    {
        get
        {
            return this.Iter.Index;
        }
        set
        {
        }
    }

    public override object Value
    {
        get
        {   
            return this.Iter.Value;
        }
        set
        {
        }
    }
}