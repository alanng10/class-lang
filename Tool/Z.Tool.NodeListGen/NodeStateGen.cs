namespace Z.Tool.NodeListGen;

public class NodeStateGen : ToolBase
{
    public virtual Table ClassTable { get; set; }
    private String OutputFoldPath { get; set; }
    private String NodeStateSourceFileName { get; set; }

    public virtual int Execute()
    {
        this.NodeStateSourceFileName = this.S("ToolData/Saber/NodeStateSource.txt");
        this.OutputFoldPath = this.S("../../Saber/Saber.Node");

        String kk;
        kk = this.ToolInfra.StorageTextRead(this.NodeStateSourceFileName);

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            String kind;
            kind = varClass.Name;

            Text k;
            k = this.TextCreate(kk);
            k = this.Replace(k, "#NodeKind#", kind);

            String a;
            a = this.StringCreate(k);

            String path;
            path = this.GetOutputFilePath(kind);

            this.ToolInfra.StorageTextWrite(path, a);
        }
        return 0;
    }

    private String GetOutputFilePath(String kind)
    {
        String fileName;
        fileName = this.AddClear().AddS("Z_NodeState_").Add(kind).AddS(".cs").AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.OutputFoldPath).AddS("/").Add(fileName).AddResult();
        return filePath;
    }
}