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

    public virtual Case Unconnected { get { return __D_Unconnected; } set { __D_Unconnected = value; } }
    protected Case __D_Unconnected;
    public virtual Case HostLookup { get { return __D_HostLookup; } set { __D_HostLookup = value; } }
    protected Case __D_HostLookup;
    public virtual Case Connecting { get { return __D_Connecting; } set { __D_Connecting = value; } }
    protected Case __D_Connecting;
    public virtual Case Connected { get { return __D_Connected; } set { __D_Connected = value; } }
    protected Case __D_Connected;
    public virtual Case Bound { get { return __D_Bound; } set { __D_Bound = value; } }
    protected Case __D_Bound;
    public virtual Case Listening { get { return __D_Listening; } set { __D_Listening = value; } }
    protected Case __D_Listening;
    public virtual Case Closing { get { return __D_Closing; } set { __D_Closing = value; } }
    protected Case __D_Closing;

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