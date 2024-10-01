namespace Avalon.Network;

public class StatusList : Any
{
    public static StatusList This { get; } = ShareCreate();

    private static StatusList ShareCreate()
    {
        StatusList share;
        share = new StatusList();
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

        this.NoError = this.AddItem();
        this.CloseError = this.AddItem();
        this.HostError = this.AddItem();
        this.OtherError = this.AddItem();
        return true;
    }

    public virtual Status NoError { get; set; }
    public virtual Status CloseError { get; set; }
    public virtual Status HostError { get; set; }
    public virtual Status OtherError { get; set; }

    protected virtual Status AddItem()
    {
        Status item;
        item = new Status();
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

    protected virtual long ArrayCount { get { return 4; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual Status Get(long index)
    {
        return (Status)this.Array.GetAt(index);
    }
}