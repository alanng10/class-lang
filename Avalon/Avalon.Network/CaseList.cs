namespace Avalon.Network;

public class CaseList : Any
{
    public static CaseList This { get; } = ShareCreate();

    private static CaseList ShareCreate()
    {
        CaseList share;
        share = new CaseList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        this.Close = this.AddItem();
        this.Open = this.AddItem();
        return true;
    }

    public virtual Case Close { get; set; }
    public virtual Case Open { get; set; }

    protected virtual Case AddItem()
    {
        Case item;
        item = new Case();
        item.Init();
        item.Index = this.Index;
        this.Array.SetAt(item.Index, item);
        this.Index = this.Index + 1;
        return item;
    }

    protected virtual bool InitArray()
    {
        this.Array = new Array();
        this.Array.Count = this.ArrayCount;
        this.Array.Init();
        return true;
    }

    protected virtual Array Array { get; set; }

    protected virtual long ArrayCount { get { return 2; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual Case Get(long index)
    {
        return (Case)this.Array.GetAt(index);
    }
}