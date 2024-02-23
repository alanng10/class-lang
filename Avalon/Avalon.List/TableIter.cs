namespace Avalon.List;

public class TableIter : Iter
{
    internal virtual Iter ListIter { get; set; }

    public override bool Next()
    {
        return this.ListIter.Next();
    }

    public override object Index
    {
        get
        {
            return this.Entry().Index;
        }
        set
        {
        }
    }

    public override object Value
    {
        get
        {
            return this.Entry().Value;
        }
        set
        {
        }
    }

    private Entry Entry()
    {
        Entry a;            
        a = (Entry)this.ListIter.Value;
        return a;
    }
}