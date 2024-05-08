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
    protected virtual string SourceTemplate { get; set; }
    
    public virtual int Execute()
    {
        this.SourceTemplate = this.ToolInfra.StorageTextRead("ToolData/Entry.txt");

        this.ExecuteOne("Class.CountList");
        return 0;
    }

    protected virtual bool ExecuteOne(string toolName)
    {
        string a;
        a = this.SourceTemplate.Replace("#Name#", toolName);

        string k;
        k = "../../Tool/Z.Tool." + toolName + "/Entry.cs";

        this.ToolInfra.StorageTextWrite(k, a);
        return true;
    }
}