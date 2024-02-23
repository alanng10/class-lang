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
        this.BrushInfra = BrushInfra.This;
        this.ColorCompMax = byte.MaxValue;
        this.WhiteColor = this.ColorCreate(this.ColorCompMax, this.ColorCompMax, this.ColorCompMax, this.ColorCompMax);
        this.BlackColor = this.ColorCreate(this.ColorCompMax, 0, 0, 0);
        this.TransparentColor = this.ColorCreate(0, 0, 0, 0);

        BrushKindList brushKindList;
        brushKindList = BrushKindList.This;
        PenKindList penKindList;
        penKindList = PenKindList.This;
        PenCapList penCapList;
        penCapList = PenCapList.This;
        PenJoinList penJoinList;
        penJoinList = PenJoinList.This;

        this.WhiteBrush = new Brush();
        this.WhiteBrush.Kind = brushKindList.Solid;
        this.WhiteBrush.Color = this.WhiteColor;
        this.WhiteBrush.Init();
        this.BlackBrush = new Brush();
        this.BlackBrush.Kind = brushKindList.Solid;
        this.BlackBrush.Color = this.BlackColor;
        this.BlackBrush.Init();
        this.BlackPen = new Pen();
        this.BlackPen.Kind = penKindList.Solid;
        this.BlackPen.Width = 1;
        this.BlackPen.Brush = this.BlackBrush;
        this.BlackPen.Cap = penCapList.Flat;
        this.BlackPen.Join = penJoinList.Miter;
        this.BlackPen.Init();

        this.Font = new Font();
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

    private BrushInfra BrushInfra { get; set; }

    public virtual int ColorCompMax { get; set; }
    public virtual Color WhiteColor { get; set; }
    public virtual Color BlackColor { get; set; }
    public virtual Color TransparentColor { get; set; }
    public virtual Brush WhiteBrush { get; set; }
    public virtual Brush BlackBrush { get; set; }
    public virtual Pen BlackPen { get; set; }
    public virtual Font Font { get; set; }
    public virtual long ScaleFactor { get; set; }

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


    internal virtual bool SetColor(Color color, ulong internColor)
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
        pos.Left = left;
        pos.Up = up;
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

    public virtual Image ImageCreateSize(Size size)
    {
        Image a;
        a = new Image();
        a.Init();

        VideoVideo video;
        video = a.Video;
        video.Size.Width = size.Width;
        video.Size.Height = size.Height;
        video.CreateData();
        a.SetSize();
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

        if (storage.Status == 0)
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

    public virtual bool WriteImage(string path, Image image, ImageFormat format)
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
        if (storage.Status == 0)
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






    public virtual bool VideoFrameGetImage(VideoFrame frame, Image image)
    {
        frame.GetVideo(image.Video);



        image.SetSize();




        return true;
    }






    public virtual bool BoundArea(Rect bound, Rect area)
    {
        int left;

        left = area.Pos.Left;



        int up;

        up = area.Pos.Up;




        int width;

        width = area.Size.Width;



        int height;

        height = area.Size.Height;




        int right;

        right = left + width;



        int down;

        down = up + height;





        int boundRight;

        boundRight = bound.Pos.Left + bound.Size.Width;



        int boundDown;

        boundDown = bound.Pos.Up + bound.Size.Height;





        if (left < bound.Pos.Left)
        {
            left = bound.Pos.Left;
        }



        if (up < bound.Pos.Up)
        {
            up = bound.Pos.Up;
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





        area.Pos.Left = left;


        area.Pos.Up = up;


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