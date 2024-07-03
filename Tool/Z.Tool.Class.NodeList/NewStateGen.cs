namespace Z.Tool.Class.NodeList;

public class NewStateGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    private string OutputFoldPath { get; set; }
    private string NewStateSourceFileName { get; set; }

    public virtual int Execute()
    {
        this.NewStateSourceFileName = "ToolData/NewStateSource.txt";
        this.OutputFoldPath = "../../Class/Class.Node";

        string kk;
        kk = this.ToolInfra.StorageTextRead(this.NewStateSourceFileName);

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        
        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            string kind;
            kind = varClass.Name;

            string k;
            k = kk.Replace("#NodeKind#", kind);

            string path;
            path = this.GetOutputFilePath(kind);

            this.ToolInfra.StorageTextWrite(path, k);
        }
        return 0;
    }

    private string GetOutputFilePath(string kind)
    {
        string fileName;
        fileName = "Z_NewState_" + kind + ".cs";
        
        string filePath;
        filePath = this.OutputFoldPath + "/" + fileName;
        return filePath;
    }
}