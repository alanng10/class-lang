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

    public virtual long ParamCount()
    {
        return 0;
    }

    public virtual bool Static()
    {
        return false;
    }
}