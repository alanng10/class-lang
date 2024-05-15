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
}