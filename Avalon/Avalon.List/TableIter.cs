namespace Avalon.List;

public class TableIter : Iter
{
    public override bool Init()
    {
        base.Init();
        this.ListIter = new Iter();
        this.ListIter.Init();
        return true;
    }

    internal virtual Iter ListIter { get; set; }

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

    public override bool Next()
    {
        return this.ListIter.Next();
    }

    private Entry Entry()
    {
        Entry a;
        a = this.ListIter.Value as Entry;
        return a;
    }

    public override bool Clear()
    {
        this.ListIter.Clear();
        return true;
    }
}