namespace Avalon.Draw;

public class CompositeList : Any
{
    public static CompositeList This { get; } = ShareCreate();

    private static CompositeList ShareCreate()
    {
        CompositeList share;
        share = new CompositeList();
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

        this.SourceOver = this.AddItem(Extern.Stat_CompositeSourceOver(stat));
        this.DestinationOver = this.AddItem(Extern.Stat_CompositeDestinationOver(stat));
        this.Clear = this.AddItem(Extern.Stat_CompositeClear(stat));
        this.Source = this.AddItem(Extern.Stat_CompositeSource(stat));
        this.Destination = this.AddItem(Extern.Stat_CompositeDestination(stat));
        this.SourceIn = this.AddItem(Extern.Stat_CompositeSourceIn(stat));
        this.DestinationIn = this.AddItem(Extern.Stat_CompositeDestinationIn(stat));
        this.SourceOut = this.AddItem(Extern.Stat_CompositeSourceOut(stat));
        this.DestinationOut = this.AddItem(Extern.Stat_CompositeDestinationOut(stat));
        this.SourceAtop = this.AddItem(Extern.Stat_CompositeSourceAtop(stat));
        this.DestinationAtop = this.AddItem(Extern.Stat_CompositeDestinationAtop(stat));
        this.Xor = this.AddItem(Extern.Stat_CompositeXor(stat));
        this.Plus = this.AddItem(Extern.Stat_CompositePlus(stat));
        this.Multiply = this.AddItem(Extern.Stat_CompositeMultiply(stat));
        this.Screen = this.AddItem(Extern.Stat_CompositeScreen(stat));
        this.Overlay = this.AddItem(Extern.Stat_CompositeOverlay(stat));
        this.Darken = this.AddItem(Extern.Stat_CompositeDarken(stat));
        this.Lighten = this.AddItem(Extern.Stat_CompositeLighten(stat));
        this.ColorDodge = this.AddItem(Extern.Stat_CompositeColorDodge(stat));
        this.ColorBurn = this.AddItem(Extern.Stat_CompositeColorBurn(stat));
        this.HardLight = this.AddItem(Extern.Stat_CompositeHardLight(stat));
        this.SoftLight = this.AddItem(Extern.Stat_CompositeSoftLight(stat));
        this.Difference = this.AddItem(Extern.Stat_CompositeDifference(stat));
        this.Exclusion = this.AddItem(Extern.Stat_CompositeExclusion(stat));
        return true;
    }

    public virtual Composite SourceOver { get { return __D_SourceOver; } set { __D_SourceOver = value; } }
    protected Composite __D_SourceOver;
    public virtual Composite DestinationOver { get { return __D_DestinationOver; } set { __D_DestinationOver = value; } }
    protected Composite __D_DestinationOver;
    public virtual Composite Clear { get { return __D_Clear; } set { __D_Clear = value; } }
    protected Composite __D_Clear;
    public virtual Composite Source { get { return __D_Source; } set { __D_Source = value; } }
    protected Composite __D_Source;
    public virtual Composite Destination { get { return __D_Destination; } set { __D_Destination = value; } }
    protected Composite __D_Destination;
    public virtual Composite SourceIn { get { return __D_SourceIn; } set { __D_SourceIn = value; } }
    protected Composite __D_SourceIn;
    public virtual Composite DestinationIn { get { return __D_DestinationIn; } set { __D_DestinationIn = value; } }
    protected Composite __D_DestinationIn;
    public virtual Composite SourceOut { get { return __D_SourceOut; } set { __D_SourceOut = value; } }
    protected Composite __D_SourceOut;
    public virtual Composite DestinationOut { get { return __D_DestinationOut; } set { __D_DestinationOut = value; } }
    protected Composite __D_DestinationOut;
    public virtual Composite SourceAtop { get { return __D_SourceAtop; } set { __D_SourceAtop = value; } }
    protected Composite __D_SourceAtop;
    public virtual Composite DestinationAtop { get { return __D_DestinationAtop; } set { __D_DestinationAtop = value; } }
    protected Composite __D_DestinationAtop;
    public virtual Composite Xor { get { return __D_Xor; } set { __D_Xor = value; } }
    protected Composite __D_Xor;
    public virtual Composite Plus { get { return __D_Plus; } set { __D_Plus = value; } }
    protected Composite __D_Plus;
    public virtual Composite Multiply { get { return __D_Multiply; } set { __D_Multiply = value; } }
    protected Composite __D_Multiply;
    public virtual Composite Screen { get { return __D_Screen; } set { __D_Screen = value; } }
    protected Composite __D_Screen;
    public virtual Composite Overlay { get { return __D_Overlay; } set { __D_Overlay = value; } }
    protected Composite __D_Overlay;
    public virtual Composite Darken { get { return __D_Darken; } set { __D_Darken = value; } }
    protected Composite __D_Darken;
    public virtual Composite Lighten { get { return __D_Lighten; } set { __D_Lighten = value; } }
    protected Composite __D_Lighten;
    public virtual Composite ColorDodge { get { return __D_ColorDodge; } set { __D_ColorDodge = value; } }
    protected Composite __D_ColorDodge;
    public virtual Composite ColorBurn { get { return __D_ColorBurn; } set { __D_ColorBurn = value; } }
    protected Composite __D_ColorBurn;
    public virtual Composite HardLight { get { return __D_HardLight; } set { __D_HardLight = value; } }
    protected Composite __D_HardLight;
    public virtual Composite SoftLight { get { return __D_SoftLight; } set { __D_SoftLight = value; } }
    protected Composite __D_SoftLight;
    public virtual Composite Difference { get { return __D_Difference; } set { __D_Difference = value; } }
    protected Composite __D_Difference;
    public virtual Composite Exclusion { get { return __D_Exclusion; } set { __D_Exclusion = value; } }
    protected Composite __D_Exclusion;

    protected virtual Composite AddItem(ulong o)
    {
        Composite item;
        item = new Composite();
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

    protected virtual int ArrayCount { get { return 24; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual Composite Get(int index)
    {
        return (Composite)this.Array.Get(index);
    }
}