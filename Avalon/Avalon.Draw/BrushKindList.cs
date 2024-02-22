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

    public virtual BrushKind Solid { get; set; }
    public virtual BrushKind Dense1 { get; set; }
    public virtual BrushKind Dense2 { get; set; }
    public virtual BrushKind Dense3 { get; set; }
    public virtual BrushKind Dense4 { get; set; }
    public virtual BrushKind Dense5 { get; set; }
    public virtual BrushKind Dense6 { get; set; }
    public virtual BrushKind Dense7 { get; set; }
    public virtual BrushKind Hor { get; set; }
    public virtual BrushKind Ver { get; set; }
    public virtual BrushKind Cross { get; set; }
    public virtual BrushKind BDiag { get; set; }
    public virtual BrushKind FDiag { get; set; }
    public virtual BrushKind DiagCross { get; set; }
    public virtual BrushKind LinearGradient { get; set; }
    public virtual BrushKind RadialGradient { get; set; }
    public virtual BrushKind ConicalGradient { get; set; }
    public virtual BrushKind Texture { get; set; }

    protected virtual BrushKind AddItem(ulong o)
    {
        BrushKind item;
        item = new BrushKind();
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

    protected virtual Array Array { get; set; }

    protected virtual int ArrayCount
    { 
        get
        {
            return 18;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual BrushKind Get(int index)
    {
        return (BrushKind)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}