namespace Avalon.Draw;

public class GradientKindList : Any
{
    public static GradientKindList This { get; } = ShareCreate();

    private static GradientKindList ShareCreate()
    {
        GradientKindList share;
        share = new GradientKindList();
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

        ulong share;
        share = Extern.Infra_Share();
        ulong stat;
        stat = Extern.Share_Stat(share);

        this.Linear = this.AddItem(Extern.Stat_GradientKindLinear(stat));
        this.Radial = this.AddItem(Extern.Stat_GradientKindRadial(stat));
        this.Conical = this.AddItem(Extern.Stat_GradientKindConical(stat));
        return true;
    }

    public virtual GradientKind Linear { get { return __D_Linear; } set { __D_Linear = value; } }
    protected GradientKind __D_Linear;
    public virtual GradientKind Radial { get { return __D_Radial; } set { __D_Radial = value; } }
    protected GradientKind __D_Radial;
    public virtual GradientKind Conical { get { return __D_Conical; } set { __D_Conical = value; } }
    protected GradientKind __D_Conical;

    protected virtual GradientKind AddItem(ulong o)
    {
        GradientKind item;
        item = new GradientKind();
        item.Init();
        item.Index = this.Index;
        item.Intern = o;
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

    protected virtual int ArrayCount { get { return 3; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual GradientKind Get(int index)
    {
        return (GradientKind)this.Array.Get(index);
    }
}