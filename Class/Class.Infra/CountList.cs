namespace Class.Infra;

public class CountList : Any
{
    public static CountList This { get; } = ShareCreate();

    private static CountList ShareCreate()
    {
        CountList share;
        share = new CountList();
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

        this.Prudate = this.AddItem();
        this.Probate = this.AddItem();
        this.Precate = this.AddItem();
        this.Private = this.AddItem();
        return true;
    }

    public virtual Count Prudate { get; set; }
    public virtual Count Probate { get; set; }
    public virtual Count Precate { get; set; }
    public virtual Count Private { get; set; }

    protected virtual Count AddItem()
    {
        Count item;
        item = new Count();
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
            return 4;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual Count Get(int index)
    {
        return (Count)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}