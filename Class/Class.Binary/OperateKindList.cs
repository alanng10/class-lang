namespace Class.Binary;

public class OperateKindList : Any
{
    public static OperateKindList This { get; } = ShareCreate();

    private static OperateKindList ShareCreate()
    {
        OperateKindList share;
        share = new OperateKindList();
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

        this.Inf = this.AddItem(false, false);
        this.While = this.AddItem(false, false);
        this.Return = this.AddItem(false, false);
        this.End = this.AddItem(false, false);
        this.BlockStart = this.AddItem(false, false);
        this.BlockEnd = this.AddItem(false, false);
        this.Assign = this.AddItem(false, false);
        this.ItemGet = this.AddItem(true, false);
        this.Call = this.AddItem(true, false);
        this.SetTarget = this.AddItem(true, false);
        this.VarTarget = this.AddItem(true, false);
        this.Var = this.AddItem(true, false);
        this.BoolValue = this.AddItem(true, false);
        this.IntValue = this.AddItem(true, false);
        this.StringValue = this.AddItem(false, true);
        this.Argue = this.AddItem(false, false);
        this.ItemThis = this.AddItem(false, false);
        this.Base = this.AddItem(false, false);
        this.Null = this.AddItem(false, false);
        this.New = this.AddItem(true, false);
        this.Share = this.AddItem(true, false);
        this.Cast = this.AddItem(true, false);
        this.Equal = this.AddItem(false, false);
        this.And = this.AddItem(false, false);
        this.Orn = this.AddItem(false, false);
        this.Not = this.AddItem(false, false);
        this.Add = this.AddItem(false, false);
        this.Sub = this.AddItem(false, false);
        this.Mul = this.AddItem(false, false);
        this.Div = this.AddItem(false, false);
        this.Less = this.AddItem(false, false);
        this.BitAnd = this.AddItem(false, false);
        this.BitOrn = this.AddItem(false, false);
        this.BitNot = this.AddItem(false, false);
        this.BitLeft = this.AddItem(false, false);
        this.BitRight = this.AddItem(false, false);
        return true;
    }

    public virtual OperateKind Inf { get; set; }
    public virtual OperateKind While { get; set; }
    public virtual OperateKind Return { get; set; }
    public virtual OperateKind End { get; set; }
    public virtual OperateKind BlockStart { get; set; }
    public virtual OperateKind BlockEnd { get; set; }
    public virtual OperateKind Assign { get; set; }
    public virtual OperateKind ItemGet { get; set; }
    public virtual OperateKind Call { get; set; }
    public virtual OperateKind SetTarget { get; set; }
    public virtual OperateKind VarTarget { get; set; }
    public virtual OperateKind Var { get; set; }
    public virtual OperateKind BoolValue { get; set; }
    public virtual OperateKind IntValue { get; set; }
    public virtual OperateKind StringValue { get; set; }
    public virtual OperateKind Argue { get; set; }
    public virtual OperateKind ItemThis { get; set; }
    public virtual OperateKind Base { get; set; }
    public virtual OperateKind Null { get; set; }
    public virtual OperateKind New { get; set; }
    public virtual OperateKind Share { get; set; }
    public virtual OperateKind Cast { get; set; }
    public virtual OperateKind Equal { get; set; }
    public virtual OperateKind And { get; set; }
    public virtual OperateKind Orn { get; set; }
    public virtual OperateKind Not { get; set; }
    public virtual OperateKind Add { get; set; }
    public virtual OperateKind Sub { get; set; }
    public virtual OperateKind Mul { get; set; }
    public virtual OperateKind Div { get; set; }
    public virtual OperateKind Less { get; set; }
    public virtual OperateKind BitAnd { get; set; }
    public virtual OperateKind BitOrn { get; set; }
    public virtual OperateKind BitNot { get; set; }
    public virtual OperateKind BitLeft { get; set; }
    public virtual OperateKind BitRight { get; set; }

    protected virtual OperateKind AddItem(bool arg, bool anyArg)
    {
        OperateKind item;
        item = new OperateKind();
        item.Init();
        item.Index = this.Index;
        item.Arg = arg;
        item.AnyArg = anyArg;
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
            return 36;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual OperateKind Get(int index)
    {
        return (OperateKind)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}