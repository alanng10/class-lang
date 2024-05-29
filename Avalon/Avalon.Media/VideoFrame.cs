namespace Avalon.Media;

public class VideoFrame : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.VideoFrame_New();
        Extern.VideoFrame_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.VideoFrame_Final(this.Intern);
        Extern.VideoFrame_Delete(this.Intern);
        return true;
    }

    internal virtual ulong Intern { get; set; }

    public virtual bool Video(Image image)
    {
        Extern.VideoFrame_Image(this.Intern, image.Ident);
        return true;
    }
}