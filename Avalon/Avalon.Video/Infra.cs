namespace Avalon.Video;

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

        this.PointByteCount = 4;
        this.ColorCompMax = byte.MaxValue;
        return true;
    }

    public virtual long PointByteCount { get; set; }
    public virtual long ColorCompMax { get; set; }


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
        ulong k;
        k = 0;
        k = k | ((((ulong)color.Blue) & 0xff) << (0 * 8));
        k = k | ((((ulong)color.Green) & 0xff) << (1 * 8));
        k = k | ((((ulong)color.Red) & 0xff) << (2 * 8));
        k = k | ((((ulong)color.Alpha) & 0xff) << (3 * 8));
        return k;
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
}