namespace Avalon.Draw;

public class Image : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.Size = new Size();
        this.Size.Init();
        this.Video = new VideoVideo();
        this.Video.Init();
        return true;
    }

    public virtual bool Final()
    {
        this.Video.Final();
        return true;
    }

    public virtual Size Size { get; set; }
    public virtual VideoVideo Video { get; set; }

    private InternIntern InternIntern { get; set; }

    public virtual bool SetSize()
    {
        Size size;
        size = this.Size;

        VideoSize sizeA;
        sizeA = this.Video.Size;
        size.Width = sizeA.Width;
        size.Height = sizeA.Height;
        return true;
    }

    public virtual bool SetData(Image dest, Pos destPos, Rect rect)
    {
        Pos aa;
        aa = rect.Pos;
        Size ab;
        ab = rect.Size;

        this.InternIntern.CopyImageData(dest.Video.Data, dest.Video.RowByteCount, destPos.Left, destPos.Up,  
            this.Video.Data, this.Video.RowByteCount, aa.Left, aa.Up, ab.Width, ab.Height);
        return true;
    }
}