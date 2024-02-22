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

        this.Unconnected = this.AddItem();
        this.HostLookup = this.AddItem();
        this.Connecting = this.AddItem();
        this.Connected = this.AddItem();
        this.Bound = this.AddItem();
        this.Listening = this.AddItem();
        this.Closing = this.AddItem();

        return true;
    }

    public virtual Case Unconnected { get; set; }
    public virtual Case HostLookup { get; set; }
    public virtual Case Connecting { get; set; }
    public virtual Case Connected { get; set; }
    public virtual Case Bound { get; set; }
    public virtual Case Listening { get; set; }
    public virtual Case Closing { get; set; }

    protected virtual Case AddItem()
    {
        Case item;
        item = new Case();
        item.Init();
        item.Index = this.Index;
        this.Array.Set(item.Index, item);
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

    protected virtual int ArrayCount
    { 
        get
        {
            return 7;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual Case Get(int index)
    {
        return (Case)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }

}