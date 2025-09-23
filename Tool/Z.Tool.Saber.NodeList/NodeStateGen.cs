namespace Z.Tool.NodeListGen;

public class NodeStateGen : ToolBase
{
    public override bool Init()
    {
        base.Init();
        this.OutputFoldPath = this.S("../../Saber/Saber.Node");
        this.NodeStateSourceFileName = this.S("ToolData/Saber/NodeStateSource.txt");
        return true;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual String OutputFoldPath { get; set; }
    protected virtual String NodeStateSourceFileName { get; set; }

    public virtual int Execute()
    {
        String kk;
        kk = this.StorageTextRead(this.NodeStateSourceFileName);

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
            k = this.Place(k, "#NodeKind#", kind);

            String a;
            a = this.StringCreate(k);

            String path;
            path = this.OutputFilePath(kind);

            this.StorageTextWrite(path, a);
        }
        return 0;
    }

    protected virtual String OutputFilePath(String kind)
    {
        String fileName;
        fileName = this.AddClear().AddS("Z_NodeState_").Add(kind).AddS(".cs").AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.OutputFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();
        return filePath;
    }
}