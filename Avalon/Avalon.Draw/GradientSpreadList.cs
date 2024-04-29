namespace Avalon.Draw;

public class GradientSpreadList : Any
{
    public static GradientSpreadList This { get; } = ShareCreate();

    private static GradientSpreadList ShareCreate()
    {
        GradientSpreadList share;
        share = new GradientSpreadList();
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

        this.Pad = this.AddItem(Extern.Stat_GradientSpreadPad(stat));
        this.Reflect = this.AddItem(Extern.Stat_GradientSpreadReflect(stat));
        this.Repeat = this.AddItem(Extern.Stat_GradientSpreadRepeat(stat));
        return true;
    }

    public virtual GradientSpread Pad { get { return __D_Pad; } set { __D_Pad = value; } }
    protected GradientSpread __D_Pad;
    public virtual GradientSpread Reflect { get { return __D_Reflect; } set { __D_Reflect = value; } }
    protected GradientSpread __D_Reflect;
    public virtual GradientSpread Repeat { get { return __D_Repeat; } set { __D_Repeat = value; } }
    protected GradientSpread __D_Repeat;

    protected virtual GradientSpread AddItem(ulong o)
    {
        GradientSpread item;
        item = new GradientSpread();
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

    public virtual GradientSpread Get(int index)
    {
        return (GradientSpread)this.Array.Get(index);
    }
}