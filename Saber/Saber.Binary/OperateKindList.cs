namespace Saber.Binary;

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

        this.End = this.AddItem(0);
        this.Ret = this.AddItem(0);
        this.Refer = this.AddItem(1);
        this.Are = this.AddItem(1);
        this.InfStart = this.AddItem(0);
        this.InfEnd = this.AddItem(0);
        this.WhileStart = this.AddItem(0);
        this.While = this.AddItem(0);
        this.WhileEnd = this.AddItem(0);
        this.ItemGet = this.AddItem(1);
        this.Set = this.AddItem(1);
        this.Call = this.AddItem(2);
        this.Var = this.AddItem(1);
        this.VarMark = this.AddItem(1);
        this.New = this.AddItem(1);
        this.Share = this.AddItem(1);
        this.Cast = this.AddItem(1);
        this.ItemThis = this.AddItem(0);
        this.Base = this.AddItem(0);
        this.Null = this.AddItem(0);
        this.Same = this.AddItem(0);
        this.Less = this.AddItem(0);
        this.And = this.AddItem(0);
        this.Orn = this.AddItem(0);
        this.Not = this.AddItem(0);
        this.Add = this.AddItem(0);
        this.Sub = this.AddItem(0);
        this.Mul = this.AddItem(0);
        this.Div = this.AddItem(0);
        this.SignLess = this.AddItem(0);
        this.SignMul = this.AddItem(0);
        this.SignDiv = this.AddItem(0);
        this.BitAnd = this.AddItem(0);
        this.BitOrn = this.AddItem(0);
        this.BitNot = this.AddItem(0);
        this.BitLite = this.AddItem(0);
        this.BitRite = this.AddItem(0);
        this.BitSignRite = this.AddItem(0);
        this.BoolValue = this.AddItem(1);
        this.IntValue = this.AddItem(1);
        this.StringValue = this.AddItem(1);
        return true;
    }

    public virtual OperateKind End { get; set; }
    public virtual OperateKind Ret { get; set; }
    public virtual OperateKind Refer { get; set; }
    public virtual OperateKind Are { get; set; }
    public virtual OperateKind InfStart { get; set; }
    public virtual OperateKind InfEnd { get; set; }
    public virtual OperateKind WhileStart { get; set; }
    public virtual OperateKind While { get; set; }
    public virtual OperateKind WhileEnd { get; set; }
    public virtual OperateKind ItemGet { get; set; }
    public virtual OperateKind Set { get; set; }
    public virtual OperateKind Call { get; set; }
    public virtual OperateKind Var { get; set; }
    public virtual OperateKind VarMark { get; set; }
    public virtual OperateKind New { get; set; }
    public virtual OperateKind Share { get; set; }
    public virtual OperateKind Cast { get; set; }
    public virtual OperateKind ItemThis { get; set; }
    public virtual OperateKind Base { get; set; }
    public virtual OperateKind Null { get; set; }
    public virtual OperateKind Same { get; set; }
    public virtual OperateKind Less { get; set; }
    public virtual OperateKind And { get; set; }
    public virtual OperateKind Orn { get; set; }
    public virtual OperateKind Not { get; set; }
    public virtual OperateKind Add { get; set; }
    public virtual OperateKind Sub { get; set; }
    public virtual OperateKind Mul { get; set; }
    public virtual OperateKind Div { get; set; }
    public virtual OperateKind SignLess { get; set; }
    public virtual OperateKind SignMul { get; set; }
    public virtual OperateKind SignDiv { get; set; }
    public virtual OperateKind BitAnd { get; set; }
    public virtual OperateKind BitOrn { get; set; }
    public virtual OperateKind BitNot { get; set; }
    public virtual OperateKind BitLite { get; set; }
    public virtual OperateKind BitRite { get; set; }
    public virtual OperateKind BitSignRite { get; set; }
    public virtual OperateKind BoolValue { get; set; }
    public virtual OperateKind IntValue { get; set; }
    public virtual OperateKind StringValue { get; set; }

    protected virtual OperateKind AddItem(long arg)
    {
        OperateKind item;
        item = new OperateKind();
        item.Init();
        item.Index = this.Index;
        item.Arg = arg;
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

    protected virtual long ArrayCount { get { return 41; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual OperateKind Get(long index)
    {
        return this.Array.GetAt(index) as OperateKind;
    }
}