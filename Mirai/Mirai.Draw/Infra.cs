namespace Mirai.Draw;

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
        this.TextInfra = TextInfra.This;
        this.StorageStatusList = StorageStatusList.This;
        this.BrushInfra = BrushInfra.This;
        this.BrushKindList = BrushKindList.This;
        this.BrushLineList = BrushLineList.This;
        this.BrushCapList = BrushCapList.This;
        this.BrushJoinList = BrushJoinList.This;

        this.PixelByteCount = 4;

        this.ColorCompMax = byte.MaxValue;

        Color blackColor;
        blackColor = this.ColorCreate(this.ColorCompMax, 0, 0, 0);

        Color whiteColor;
        whiteColor = this.ColorCreate(this.ColorCompMax, this.ColorCompMax, this.ColorCompMax, this.ColorCompMax);

        Color transparentColor;
        transparentColor = this.ColorCreate(0, 0, 0, 0);

        MathMath math;
        math = new MathMath();
        math.Init();
        MathComp ka;
        ka = new MathComp();
        ka.Init();

        long k;
        k = this.MathInfra.Int(math, ka, 1);

        this.BlackBrush = this.CreateBrush(blackColor, k);
        this.WhiteBrush = this.CreateBrush(whiteColor, k);
        this.ZeroBrush = this.CreateBrush(transparentColor, k);

        this.Font = new Face();
        this.Font.Name = this.TextInfra.S("Source Sans 3");
        this.Font.Size = 10;
        this.Font.Weight = 400;
        this.Font.Init();

        long a;
        a = 1 << 20;
        this.ScaleFactor = a;
        return true;
    }

    public virtual long PixelByteCount { get; set; }
    public virtual long ColorCompMax { get; set; }
    public virtual Brush BlackBrush { get; set; }
    public virtual Brush WhiteBrush { get; set; }
    public virtual Brush ZeroBrush { get; set; }
    public virtual Face Font { get; set; }
    private long ScaleFactor { get; set; }
    protected virtual MathInfra MathInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
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

    private Brush CreateBrush(Color color, long wed)
    {
        Brush a;
        a = new Brush();
        a.Kind = this.BrushKindList.Color;
        a.Color = color;
        a.Line = this.BrushLineList.Solid;
        a.Wed = wed;
        a.Cap = this.BrushCapList.Flat;
        a.Join = this.BrushJoinList.Miter;
        a.Init();
        return a;
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

    public virtual Image ImageCreateSize(Size size)
    {
        Image a;
        a = new Image();
        a.Init();
        a.Size.Wed = size.Wed;
        a.Size.Het = size.Het;
        a.DataCreate();
        return a;
    }

    public virtual Image ImageCreateStorage(String path)
    {
        Image image;
        image = null;
        Storage storage;
        storage = new Storage();
        storage.Init();
        StorageMode mode;
        mode = new StorageMode();
        mode.Init();
        mode.Read = true;
        storage.Path = path;
        storage.Mode = mode;

        storage.Open();

        if (storage.Status == this.StorageStatusList.NoError)
        {
            Stream stream;
            stream = storage.Stream;

            Image aa;
            aa = new Image();
            aa.Init();

            ImageRead imageRead;
            imageRead = new ImageRead();
            imageRead.Init();
            imageRead.Stream = stream;
            imageRead.Image = aa;

            bool b;
            b = imageRead.Execute();
            if (b)
            {
                image = aa;
            }
            if (!b)
            {
                aa.Final();
            }
            imageRead.Final();
        }
        storage.Close();
        storage.Final();
        return image;
    }

    public virtual bool ImageWrite(String path, Image image, VideoBinary binary)
    {
        Storage storage;
        storage = new Storage();
        storage.Init();
        StorageMode mode;
        mode = new StorageMode();
        mode.Init();
        mode.Write = true;
        storage.Path = path;
        storage.Mode = mode;
        storage.Open();

        bool o;
        o = false;
        if (storage.Status == this.StorageStatusList.NoError)
        {
            Stream stream;
            stream = storage.Stream;

            ImageWrite imageWrite;
            imageWrite = new ImageWrite();
            imageWrite.Init();
            imageWrite.Stream = stream;
            imageWrite.Binary = binary;
            imageWrite.Image = image;
            o = imageWrite.Execute();
            imageWrite.Final();
        }
        storage.Close();
        storage.Final();
        return o;
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