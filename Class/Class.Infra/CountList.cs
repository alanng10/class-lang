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

    public virtual Count Prudate { get { return __D_Prudate; } set { __D_Prudate = value; } }
    protected Count __D_Prudate;
    public virtual Count Probate { get { return __D_Probate; } set { __D_Probate = value; } }
    protected Count __D_Probate;
    public virtual Count Precate { get { return __D_Precate; } set { __D_Precate = value; } }
    protected Count __D_Precate;
    public virtual Count Private { get { return __D_Private; } set { __D_Private = value; } }
    protected Count __D_Private;

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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 4; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual Count Get(int index)
    {
        return (Count)this.Array.Get(index);
    }
}