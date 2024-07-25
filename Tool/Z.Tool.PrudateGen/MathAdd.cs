namespace Z.Tool.PrudateGen;

public class MathAdd : Any
{
    public override bool Init()
    {
        base.Init();
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    public virtual ReadResult ReadResult { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }

    public virtual bool Execute()
    {
        return true;
    }
}