namespace Demo;

class VideoFrameState : State
{
    public override bool Init()
    {
        base.Init();
        this.DrawInfra = DrawInfra.This;
        this.ViewInfra = ViewInfra.This;
        return true;
    }

    public Demo Demo { get; set; }

    protected DrawInfra DrawInfra { get; set; }
    protected ViewInfra ViewInfra { get; set; }

    public override bool Execute()
    {
        VideoFrame frame;        
        frame = this.Demo.Play.VideoOut.Frame;

        frame.Image(this.Demo.PlayImage);

        this.ViewInfra.AssignDrawRectValue(this.Demo.UpdateRect, this.Demo.ViewA.Area);

        this.Demo.Frame.Update(this.Demo.UpdateRect);
        return true;
    }
}