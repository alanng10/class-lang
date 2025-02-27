namespace Z.Tool.NodeListGen;

public class NewStateGen : ToolBase
{
    public override bool Init()
    {
        base.Init();
        this.OutputFoldPath = this.S("../../Saber/Saber.Node");
        return true;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual String OutputFoldPath { get; set; }
    private String NewStateSourceFileName { get; set; }

    public virtual int Execute()
    {
        this.NewStateSourceFileName = this.S("ToolData/Saber/NewStateSource.txt");

        String kk;
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

            String kind;
            kind = varClass.Name;

            Text k;
            k = this.TextCreate(kk);
            k = this.Place(k, "#NodeKind#", kind);

            String a;
            a = this.StringCreate(k);

            String path;
            path = this.OutputFilePath(kind);

            this.ToolInfra.StorageTextWrite(path, a);
        }
        return 0;
    }

    protected virtual String OutputFilePath(String kind)
    {
        String fileName;
        fileName = this.AddClear().AddS("Z_NewState_").Add(kind).AddS(".cs").AddResult();
        
        String filePath;
        filePath = this.AddClear().Add(this.OutputFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();
        return filePath;
    }
}