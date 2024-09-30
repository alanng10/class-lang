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

    public virtual bool Image(VideoVideo video)
    {
        Extern.VideoFrame_Image(this.Intern, video.Ident);
        return true;
    }
}