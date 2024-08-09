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
        this.StorageStatusList = StorageStatusList.This;
        this.BrushInfra = BrushInfra.This;
        this.PixelByteCount = 4;
        this.ColorCompMax = byte.MaxValue;

        Color blackColor;
        blackColor = this.ColorCreate(this.ColorCompMax, 0, 0, 0);

        Color whiteColor;
        whiteColor = this.ColorCreate(this.ColorCompMax, this.ColorCompMax, this.ColorCompMax, this.ColorCompMax);
        
        Color transparentColor;
        transparentColor = this.ColorCreate(0, 0, 0, 0);

        this.BrushKindList = BrushKindList.This;
        this.BrushLineList = BrushLineList.This;
        this.BrushCapList = BrushCapList.This;
        this.BrushJoinList = BrushJoinList.This;

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
        this.Font.Family = "Source Sans 3";
        this.Font.Size = 10;
        this.Font.Weight = 400;
        this.Font.Init();

        long a;
        a = 1 << 20;
        this.ScaleFactor = a;

        ulong share;
        share = Extern.Infra_Share();
        ulong stat;
        stat = Extern.Share_Stat(share);
        this.InternWordWrap = Extern.Stat_TextWrapWordWrap(stat);
        return true;
    }

    public virtual int PixelByteCount { get; set; }
    public virtual int ColorCompMax { get; set; }
    public virtual Brush BlackBrush { get; set; }
    public virtual Brush WhiteBrush { get; set; }
    public virtual Brush TransparentBrush { get; set; }
    public virtual Face Font { get; set; }
    private long ScaleFactor { get; set; }
    protected virtual MathInfra MathInfra { get; set; }
    protected virtual StorageStatusList StorageStatusList { get; set; }
    protected virtual BrushKindList BrushKindList { get; set; }
    protected virtual BrushLineList BrushLineList { get; set; }
    protected virtual BrushCapList BrushCapList { get; set; }
    protected virtual BrushJoinList BrushJoinList { get; set; }

    private BrushInfra BrushInfra { get; set; }

    internal virtual ulong InternWordWrap { get; set; }

    public virtual Color ColorCreate(int alpha, int red, int green, int blue)
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
        color.Blue = (int)((internColor >> (0 * 8)) & 0xff);
        color.Green = (int)((internColor >> (1 * 8)) & 0xff);
        color.Red = (int)((internColor >> (2 * 8)) & 0xff);
        color.Alpha = (int)((internColor >> (3 * 8)) & 0xff);
        return true;
    }

    internal virtual ulong InternColor(Color color)
    {
        return this.BrushInfra.InternColor(color);
    }

    public virtual Pos PosCreate(int left, int up)
    {
        Pos pos;
        pos = new Pos();
        pos.Init();
        pos.Col = left;
        pos.Row = up;
        return pos;
    }

    public virtual Size SizeCreate(int width, int height)
    {
        Size size;
        size = new Size();
        size.Init();
        size.Width = width;
        size.Height = height;
        return size;
    }

    public virtual Rect RectCreate(int left, int up, int width, int height)
    {
        Rect rect;
        rect = new Rect();
        rect.Init();
        rect.Pos = this.PosCreate(left, up);
        rect.Size = this.SizeCreate(width, height);
        return rect;
    }

    public virtual PosInt PosIntCreate(long left, long up)
    {
        PosInt pos;
        pos = new PosInt();
        pos.Init();
        pos.Col = left;
        pos.Up = up;
        return pos;
    }

    public virtual SizeInt SizeIntCreate(long width, long height)
    {
        SizeInt size;
        size = new SizeInt();
        size.Init();
        size.Width = width;
        size.Height = height;
        return size;
    }

    public virtual RectInt RectIntCreate(long left, long up, long width, long height)
    {
        RectInt rect;
        rect = new RectInt();
        rect.Init();
        rect.Pos = this.PosIntCreate(left, up);
        rect.Size = this.SizeIntCreate(width, height);
        return rect;
    }

    public virtual Image ImageCreateSize(Size size)
    {
        Image a;
        a = new Image();
        a.Init();
        a.Size.Width = size.Width;
        a.Size.Height = size.Height;
        a.DataCreate();
        return a; 
    }

    public virtual Image ImageCreatePath(string path)
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

    public virtual bool ImageWrite(string path, Image image, ImageFormat format)
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
            imageWrite.Format = format;
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
        int left;
        left = area.Pos.Col;
        int up;
        up = area.Pos.Row;
        int width;
        width = area.Size.Width;
        int height;
        height = area.Size.Height;
        int right;
        right = left + width;
        int down;
        down = up + height;

        int boundRight;
        boundRight = bound.Pos.Col + bound.Size.Width;
        int boundDown;
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

        int w;
        w = this.BoundSub(right, left);
        int h;
        h = this.BoundSub(down, up);

        area.Pos.Col = left;
        area.Pos.Row = up;
        area.Size.Width = w;
        area.Size.Height = h;
        return true;
    }

    protected virtual int BoundSub(int left, int right)
    {
        int k;
        k = 0;
        if (!(left < right))
        {
            k = left - right;
        }
        return k;
    }
}