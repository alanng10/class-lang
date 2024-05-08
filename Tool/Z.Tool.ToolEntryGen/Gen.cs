namespace Z.Tool.ToolEntryGen;

class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    protected virtual ToolInfra ToolInfra { get; set; }

    public virtual int Execute()
    {
        return 0;
    }

    protected virtual bool ExecuteOne(string toolName)
    {
        return true;
    }
}