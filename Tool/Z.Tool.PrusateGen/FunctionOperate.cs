namespace Z.Tool.PrusateGen;

class FunctionOperate : ToolBase
{
    public virtual PrusateGen Gen { get; set; }
    public virtual Class Class { get; set; }

    public virtual bool ExecuteName()
    {
        return false;
    }

    public virtual bool ExecuteParam()
    {
        return false;
    }
}