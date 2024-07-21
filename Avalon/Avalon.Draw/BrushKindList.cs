namespace Avalon.Draw;

public class BrushKindList : Any
{
    public static BrushKindList This { get; } = ShareCreate();

    private static BrushKindList ShareCreate()
    {
        BrushKindList share;
        share = new BrushKindList();
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

        this.Solid = this.AddItem(Extern.Stat_BrushKindSolid(stat));
        this.Dense1 = this.AddItem(Extern.Stat_BrushKindDense1(stat));
        this.Dense2 = this.AddItem(Extern.Stat_BrushKindDense2(stat));
        this.Dense3 = this.AddItem(Extern.Stat_BrushKindDense3(stat));
        this.Dense4 = this.AddItem(Extern.Stat_BrushKindDense4(stat));
        this.Dense5 = this.AddItem(Extern.Stat_BrushKindDense5(stat));
        this.Dense6 = this.AddItem(Extern.Stat_BrushKindDense6(stat));
        this.Dense7 = this.AddItem(Extern.Stat_BrushKindDense7(stat));
        this.Hor = this.AddItem(Extern.Stat_BrushKindHor(stat));
        this.Ver = this.AddItem(Extern.Stat_BrushKindVer(stat));
        this.Cross = this.AddItem(Extern.Stat_BrushKindCross(stat));
        this.BDiag = this.AddItem(Extern.Stat_BrushKindBDiag(stat));
        this.FDiag = this.AddItem(Extern.Stat_BrushKindFDiag(stat));
        this.DiagCross = this.AddItem(Extern.Stat_BrushKindDiagCross(stat));
        this.LinearGradient = this.AddItem(Extern.Stat_BrushKindLinearGradient(stat));
        this.RadialGradient = this.AddItem(Extern.Stat_BrushKindRadialGradient(stat));
        this.ConicalGradient = this.AddItem(Extern.Stat_BrushKindConicalGradient(stat));
        this.Texture = this.AddItem(Extern.Stat_BrushKindTexture(stat));
        return true;
    }

    public virtual BrushKind Solid { get { return __D_Solid; } set { __D_Solid = value; } }
    protected BrushKind __D_Solid;
    public virtual BrushKind Dense1 { get { return __D_Dense1; } set { __D_Dense1 = value; } }
    protected BrushKind __D_Dense1;
    public virtual BrushKind Dense2 { get { return __D_Dense2; } set { __D_Dense2 = value; } }
    protected BrushKind __D_Dense2;
    public virtual BrushKind Dense3 { get { return __D_Dense3; } set { __D_Dense3 = value; } }
    protected BrushKind __D_Dense3;
    public virtual BrushKind Dense4 { get { return __D_Dense4; } set { __D_Dense4 = value; } }
    protected BrushKind __D_Dense4;
    public virtual BrushKind Dense5 { get { return __D_Dense5; } set { __D_Dense5 = value; } }
    protected BrushKind __D_Dense5;
    public virtual BrushKind Dense6 { get { return __D_Dense6; } set { __D_Dense6 = value; } }
    protected BrushKind __D_Dense6;
    public virtual BrushKind Dense7 { get { return __D_Dense7; } set { __D_Dense7 = value; } }
    protected BrushKind __D_Dense7;
    public virtual BrushKind Hor { get { return __D_Hor; } set { __D_Hor = value; } }
    protected BrushKind __D_Hor;
    public virtual BrushKind Ver { get { return __D_Ver; } set { __D_Ver = value; } }
    protected BrushKind __D_Ver;
    public virtual BrushKind Cross { get { return __D_Cross; } set { __D_Cross = value; } }
    protected BrushKind __D_Cross;
    public virtual BrushKind BDiag { get { return __D_BDiag; } set { __D_BDiag = value; } }
    protected BrushKind __D_BDiag;
    public virtual BrushKind FDiag { get { return __D_FDiag; } set { __D_FDiag = value; } }
    protected BrushKind __D_FDiag;
    public virtual BrushKind DiagCross { get { return __D_DiagCross; } set { __D_DiagCross = value; } }
    protected BrushKind __D_DiagCross;
    public virtual BrushKind LinearGradient { get { return __D_LinearGradient; } set { __D_LinearGradient = value; } }
    protected BrushKind __D_LinearGradient;
    public virtual BrushKind RadialGradient { get { return __D_RadialGradient; } set { __D_RadialGradient = value; } }
    protected BrushKind __D_RadialGradient;
    public virtual BrushKind ConicalGradient { get { return __D_ConicalGradient; } set { __D_ConicalGradient = value; } }
    protected BrushKind __D_ConicalGradient;
    public virtual BrushKind Texture { get { return __D_Texture; } set { __D_Texture = value; } }
    protected BrushKind __D_Texture;

    protected virtual BrushKind AddItem(ulong o)
    {
        BrushKind item;
        item = new BrushKind();
        item.Init();
        item.Index = this.Index;
        item.Intern = o;
        this.Array.Set((object)item.Index, item);
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

    protected virtual int ArrayCount { get { return 18; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual BrushKind Get(int index)
    {
        return (BrushKind)this.Array.Get((object)index);
    }
}