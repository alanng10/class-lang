namespace Z.Tool.Class.NodeList;

public class TraverseGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ToolInfra = ToolInfra.This;

        this.PathOutput = "../../Class/Class.Node/Traverse.cs";

        this.PathSource = this.GetPath("Source");
        this.PathNode = this.GetPath("Node");
        this.PathDerive = this.GetPath("Derive");
        this.PathExecuteNode = this.GetPath("ExecuteNode");
        this.PathArray = this.GetPath("Array");
        this.PathField = this.GetPath("Field");
        return true;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual string PathOutput { get; set; }
    protected virtual string PathSource { get; set; }
    protected virtual string PathNode { get; set; }
    protected virtual string PathDerive { get; set; }
    protected virtual string PathExecuteNode { get; set; }
    protected virtual string PathArray { get; set; }
    protected virtual string PathField { get; set; }

    public virtual bool Execute()
    {
        string textSource;
        textSource = this.ToolInfra.StorageTextRead(this.PathSource);

        string nodeList;
        nodeList = this.NodeList();

        string k;
        k = textSource.Replace("#NodeList#", nodeList);
    
        this.ToolInfra.StorageTextWrite(this.PathOutput, k);
        return true;
    }

    protected virtual string NodeList()
    {
        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        return null;
    }

    private string GetPath(string name)
    {
        return "ToolData/Traverse" + name + ".txt";
    }
}