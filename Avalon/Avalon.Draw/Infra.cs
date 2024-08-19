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
        this.TransparentBrush = this.CreateBrush(transparentColor, k);

        this.Font = new Face();
        this.Font.Family = this.TextStringValue.Execute("Source Sans 3");
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
    public virtual Brush TransparentBrush { get; set; }
    public virtual Face Font { get; set; }
    private long ScaleFactor { get; set; }
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

    private Brush CreateBrush(Color color, long width)
    {
        Brush a;
        a = new Brush();
        a.Kind = this.BrushKindList.Color;
        a.Color = color;
        a.Line = this.BrushLineList.Solid;
        a.Width = width;
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

    public virtual Pos PosCreate(long left, long up)
    {
        Pos pos;
        pos = new Pos();
        pos.Init();
        pos.Col = left;
        pos.Row = up;
        return pos;
    }

    public virtual Size SizeCreate(long width, long height)
    {
        Size size;
        size = new Size();
        size.Init();
        size.Wed = width;
        size.Height = height;
        return size;
    }

    public virtual Rect RectCreate(long left, long up, long width, long height)
    {
        Rect rect;
        rect = new Rect();
        rect.Init();
        rect.Pos = this.PosCreate(left, up);
        rect.Size = this.SizeCreate(width, height);
        return rect;
    }

    public virtual Image ImageCreateSize(Size size)
    {
        Image a;
        a = new Image();
        a.Init();
        a.Size.Wed = size.Wed;
        a.Size.Height = size.Height;
        a.DataCreate();
        return a; 
    }

    public virtual Image ImageCreatePath(String path)
    {
        Image image;
        image = null;
        StorageStorage storage;
        storage = new StorageStorage();
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
            StreamStream stream;
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

    public virtual bool ImageWrite(String path, Image image, ImageBinary binary)
    {
        StorageStorage storage;
        storage = new StorageStorage();
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
            StreamStream stream;
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
        long left;
        left = area.Pos.Col;
        long up;
        up = area.Pos.Row;
        long width;
        width = area.Size.Wed;
        long height;
        height = area.Size.Height;
        long right;
        right = left + width;
        long down;
        down = up + height;

        long boundRight;
        boundRight = bound.Pos.Col + bound.Size.Wed;
        long boundDown;
        boundDown = bound.Pos.Row + bound.Size.Height;

        if (left < bound.Pos.Col)
        {
            left = bound.Pos.Col;
        }
        if (up < bound.Pos.Row)
        {
            up = bound.Pos.Row;
        }
        if (boundRight < right)
        {
            right = boundRight;
        }
        if (boundDown < down)
        {
            down = boundDown;
        }

        long w;
        w = this.BoundSub(right, left);
        long h;
        h = this.BoundSub(down, up);

        area.Pos.Col = left;
        area.Pos.Row = up;
        area.Size.Wed = w;
        area.Size.Height = h;
        return true;
    }

    protected virtual long BoundSub(long left, long right)
    {
        long k;
        k = 0;
        if (!(left < right))
        {
            k = left - right;
        }
        return k;
    }
}