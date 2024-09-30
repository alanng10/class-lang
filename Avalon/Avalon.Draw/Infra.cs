namespace Avalon.Draw;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.MathInfra = MathInfra.This;
        this.TextStringValue = TextStringValue.This;
        this.StorageStatusList = StorageStatusList.This;
        this.BrushInfra = BrushInfra.This;
        this.BrushKindList = BrushKindList.This;
        this.BrushLineList = BrushLineList.This;
        this.BrushCapList = BrushCapList.This;
        this.BrushJoinList = BrushJoinList.This;
        return true;
    }

    protected virtual MathInfra MathInfra { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    protected virtual StorageStatusList StorageStatusList { get; set; }
    protected virtual BrushKindList BrushKindList { get; set; }
    protected virtual BrushLineList BrushLineList { get; set; }
    protected virtual BrushCapList BrushCapList { get; set; }
    protected virtual BrushJoinList BrushJoinList { get; set; }
    private BrushInfra BrushInfra { get; set; }

    public virtual Color ColorCreate(long alpha, long red, long green, long blue)
    {
        Color color;
        color = new Color();
        color.Init();
        color.Alpha = alpha;
        color.Red = red;
        color.Green = green;
        color.Blue = blue;
        return color;
    }

    internal virtual bool ColorSet(Color color, ulong internColor)
    {
        color.Blue = (long)((internColor >> (0 * 8)) & 0xff);
        color.Green = (long)((internColor >> (1 * 8)) & 0xff);
        color.Red = (long)((internColor >> (2 * 8)) & 0xff);
        color.Alpha = (long)((internColor >> (3 * 8)) & 0xff);
        return true;
    }

    internal virtual ulong InternColor(Color color)
    {
        return this.BrushInfra.InternColor(color);
    }

    public virtual Pos PosCreate(long col, long row)
    {
        Pos pos;
        pos = new Pos();
        pos.Init();
        pos.Col = col;
        pos.Row = row;
        return pos;
    }

    public virtual Size SizeCreate(long wed, long het)
    {
        Size size;
        size = new Size();
        size.Init();
        size.Wed = wed;
        size.Het = het;
        return size;
    }

    public virtual Rect RectCreate(long col, long row, long wed, long het)
    {
        Rect rect;
        rect = new Rect();
        rect.Init();
        rect.Pos = this.PosCreate(col, row);
        rect.Size = this.SizeCreate(wed, het);
        return rect;
    }

    public virtual bool BoundArea(Rect bound, Rect area)
    {
        long lite;
        lite = area.Pos.Col;
        long nite;
        nite = area.Pos.Row;
        long wed;
        wed = area.Size.Wed;
        long het;
        het = area.Size.Het;
        long rite;
        rite = lite + wed;
        long site;
        site = nite + het;

        long boundLite;
        long boundNite;
        boundLite = bound.Pos.Col;
        boundNite = bound.Pos.Row;
        long boundRite;
        long boundSite;
        boundRite = boundLite + bound.Size.Wed;
        boundSite = boundNite + bound.Size.Het;

        if (lite < boundLite)
        {
            lite = boundLite;
        }
        if (nite < boundNite)
        {
            nite = boundNite;
        }
        if (boundRite < rite)
        {
            rite = boundRite;
        }
        if (boundSite < site)
        {
            site = boundSite;
        }

        long w;
        w = this.BoundSub(rite, lite);
        long h;
        h = this.BoundSub(site, nite);

        area.Pos.Col = lite;
        area.Pos.Row = nite;
        area.Size.Wed = w;
        area.Size.Het = h;
        return true;
    }

    protected virtual long BoundSub(long lite, long rite)
    {
        long k;
        k = 0;
        if (!(lite < rite))
        {
            k = lite - rite;
        }
        return k;
    }
}