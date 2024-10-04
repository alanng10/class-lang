namespace Mirai.Media;

public class VideoOut : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.MediaInfra = Infra.This;
        this.InternHandle = new Handle();
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress ua;
        ua = this.MediaInfra.VideoOutFrameMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternFrameState = this.InternInfra.StateCreate(ua, arg);

        this.InternFrame = Extern.VideoFrame_New();
        Extern.VideoFrame_Init(this.InternFrame);

        this.Intern = Extern.VideoOut_New();
        Extern.VideoOut_Init(this.Intern);
        Extern.VideoOut_FrameStateSet(this.Intern, this.InternFrameState);

        Extern.VideoOut_FrameSet(this.Intern, this.InternFrame);
        return true;
    }

    public virtual bool Final()
    {
        Extern.VideoOut_Final(this.Intern);
        Extern.VideoOut_Delete(this.Intern);

        Extern.VideoFrame_Final(this.InternFrame);
        Extern.VideoFrame_Delete(this.InternFrame);

        this.InternInfra.StateDelete(this.InternFrameState);

        this.InternHandle.Final();
        return true;
    }

    public virtual State FrameState { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra MediaInfra { get; set; }

    internal virtual ulong Intern { get; set; }
    internal virtual ulong InternFrame { get; set; }
    private ulong InternFrameState { get; set; }
    private Handle InternHandle { get; set; }

    internal static ulong InternFrameEvent(ulong videoOut, ulong frame, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        VideoOut a;
        a = (VideoOut)ao;
        a.FrameStateExecute();
        return 1;
    }

    private bool FrameStateExecute()
    {
        if (!(this.FrameState == null))
        {
            this.FrameState.Execute();
        }
        return true;
    }

    public virtual bool Image(VideoVideo video)
    {
        Extern.VideoFrame_Image(this.InternFrame, video.Ident);
        return true;
    }
}