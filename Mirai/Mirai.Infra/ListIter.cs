namespace Mirai.Infra;

public class ListIter : Iter
{
    public override bool Init()
    {
        base.Init();
        this.Iter = new TableIter();
        this.Iter.Init();
        return true;
    }

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

    public override bool Clear()
    {
        this.Iter.Clear();
        return true;
    }
}