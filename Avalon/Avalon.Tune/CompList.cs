namespace Avalon.Tune;

public class CompList : Any
{
    public static CompList This { get; } = ShareCreate();

    private static CompList ShareCreate()
    {
        CompList share;
        share = new CompList();
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

        this.Add = this.AddItem();
        this.AddNot = this.AddItem();
        this.Set = this.AddItem();
        this.SetNot = this.AddItem();
        return true;
    }

    public virtual Comp Add { get; set; }
    public virtual Comp AddNot { get; set; }
    public virtual Comp Set { get; set; }
    public virtual Comp SetNot { get; set; }

    protected virtual Comp AddItem()
    {
        Comp item;
        item = new Comp();
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

    public virtual Comp Get(long index)
    {
        return (Comp)this.Array.GetAt(index);
    }
}