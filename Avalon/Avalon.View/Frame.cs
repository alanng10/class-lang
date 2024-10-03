namespace Avalon.View;

public class Frame : FrameFrame
{
    public override bool Init()
    {
        base.Init();
        this.ViewInfra = Infra.This;
        return true;
    }

    protected virtual Infra ViewInfra { get; set; }

    protected virtual Field CreateViewField()
    {
        return this.ViewInfra.FieldCreate(this);
    }
}