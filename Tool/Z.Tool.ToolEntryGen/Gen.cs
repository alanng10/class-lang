namespace Z.Tool.ToolEntryGen;

class Gen : ToolGen
{
    protected virtual String SourceTemplate { get; set; }

    public virtual int Execute()
    {
        this.SourceTemplate = this.ToolInfra.StorageTextRead(this.S("ToolData/Entry.txt"));

        this.ExecuteOne("Avalon.TextCodeKindList");
        this.ExecuteOne("Avalon.StorageStatusList");
        this.ExecuteOne("Avalon.NetworkCaseList");
        this.ExecuteOne("Avalon.NetworkPortKindList");
        this.ExecuteOne("Avalon.NetworkStatusList");
        this.ExecuteOne("Avalon.BrushCapList");
        this.ExecuteOne("Avalon.BrushJoinList");
        this.ExecuteOne("Avalon.BrushKindList");
        this.ExecuteOne("Avalon.BrushLineList");
        this.ExecuteOne("Avalon.DrawCompList");
        this.ExecuteOne("Avalon.GradientKindList");
        this.ExecuteOne("Avalon.GradientSpreadList");
        this.ExecuteOne("Avalon.ImageBinaryList");
        this.ExecuteOne("Class.CountList");
        this.ExecuteOne("Class.DelimitList");
        this.ExecuteOne("Class.ErrorKindList");
        this.ExecuteOne("Class.KeywordList");
        this.ExecuteOne("Class.NodeList");
        this.ExecuteOne("Class.TaskKindList");
        this.ExecuteOne("System.TextCodeKindList");
        this.ExecuteOne("System.StorageStatusList");
        this.ExecuteOne("System.NetworkCaseList");
        this.ExecuteOne("System.NetworkPortKindList");
        this.ExecuteOne("System.NetworkStatusList");
        this.ExecuteOne("System.BrushCapList");
        this.ExecuteOne("System.BrushJoinList");
        this.ExecuteOne("System.BrushKindList");
        this.ExecuteOne("System.BrushLineList");
        this.ExecuteOne("System.DrawCompList");
        this.ExecuteOne("System.GradientKindList");
        this.ExecuteOne("System.GradientSpreadList");
        this.ExecuteOne("System.ImageBinaryList");
        this.ExecuteOne("Infra.StatTextCodeKind");
        this.ExecuteOne("Infra.StatThreadCase");
        this.ExecuteOne("Infra.StatStreamKind");
        this.ExecuteOne("Infra.StatStorageMode");
        this.ExecuteOne("Infra.StatStorageStatus");
        this.ExecuteOne("Infra.StatNetworkCase");
        this.ExecuteOne("Infra.StatNetworkPortKind");
        this.ExecuteOne("Infra.StatNetworkStatus");
        this.ExecuteOne("Infra.StatBrushCap");
        this.ExecuteOne("Infra.StatBrushJoin");
        this.ExecuteOne("Infra.StatBrushKind");
        this.ExecuteOne("Infra.StatBrushLine");
        this.ExecuteOne("Infra.StatComp");
        this.ExecuteOne("Infra.StatGradientKind");
        this.ExecuteOne("Infra.StatGradientSpread");
        this.ExecuteOne("Infra.StatImageBinary");
        this.ExecuteOne("MathGen");
        this.ExecuteOne("PrudateGen");
        this.ExecuteOne("ReferBinaryGen");

        return 0;
    }

    protected virtual bool ExecuteOne(string toolName)
    {
        String ka;
        ka = this.S(toolName);

        Text k;
        k = this.TextCreate(this.SourceTemplate);
        k = this.Replace(k, "#Name#", ka);

        String a;
        a = this.StringCreate(k);

        String path;
        path = this.AddClear().AddS("../../Tool/Z.Tool.").Add(ka).AddS("/Entry.cs").AddResult();

        this.ToolInfra.StorageTextWrite(path, a);
        return true;
    }
}