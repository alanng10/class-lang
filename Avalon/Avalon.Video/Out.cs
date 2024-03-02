namespace Avalon.Video;

public class Out : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.VideoInfra = Infra.This;
        this.InternHandle = new Handle();
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress ua;
        ua = this.VideoInfra.OutFrameMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternFrameState = this.InternInfra.StateCreate(ua, arg);

        this.Intern = Extern.VideoOut_New();
        Extern.VideoOut_Init(this.Intern);
        Extern.VideoOut_FrameStateSet(this.Intern, this.InternFrameState);
        this.Ident = this.Intern;
        return true;
    }
    
    public virtual bool Final()
    {
        Extern.VideoOut_Final(this.Intern);
        Extern.VideoOut_Delete(this.Intern);

        this.InternInfra.StateDelete(this.InternFrameState);

        this.InternHandle.Final();
        return true;
    }

    protected virtual Frame FrameData { get; set; }

    public virtual Frame Frame
    {
        get
        {
            return this.FrameData;
        }
        set
        {
            this.FrameData = value;
            ulong u;
            u = 0;
            if (!(this.FrameData == null))
            {
                u = this.FrameData.Intern;
            }
            Extern.VideoOut_FrameSet(this.Intern, u);
        }
    }

    public virtual State FrameState { get; set; }
    public virtual ulong Ident { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual Infra VideoInfra { get; set; }

    internal virtual ulong Intern { get; set; }
    private ulong InternFrameState { get; set; }
    private Handle InternHandle { get; set; }

    internal static ulong InternFrame(ulong videoOut, ulong frame, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Out a;
        a = (Out)ao;
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
}