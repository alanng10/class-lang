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
        this.Demo.Play.VideoOut.Image(this.Demo.PlayImage);

        this.ViewInfra.AssignDrawRectValue(this.Demo.UpdateRect, this.Demo.ViewA.Area);

        this.Demo.Frame.EventDraw(this.Demo.UpdateRect);
        return true;
    }
}