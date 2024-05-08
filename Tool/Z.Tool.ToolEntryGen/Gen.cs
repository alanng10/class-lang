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

        this.ExecuteOne("Avalon.BrushKindList");
        this.ExecuteOne("Avalon.CompositeList");
        this.ExecuteOne("Avalon.GradientKindList");
        this.ExecuteOne("Avalon.GradientSpreadList");
        this.ExecuteOne("Avalon.ImageFormatList");
        this.ExecuteOne("Avalon.NetworkCaseList");
        this.ExecuteOne("Avalon.NetworkPortKindList");
        this.ExecuteOne("Avalon.NetworkStatusList");
        this.ExecuteOne("Avalon.PenCapList");
        this.ExecuteOne("Avalon.PenJoinList");
        this.ExecuteOne("Avalon.PenKindList");
        this.ExecuteOne("Avalon.TextAlignList");
        this.ExecuteOne("Avalon.TextEncodeKindList");
        this.ExecuteOne("Class.CountList");
        this.ExecuteOne("Class.DelimitList");
        this.ExecuteOne("Class.ErrorKindList");
        this.ExecuteOne("Class.KeywordList");
        this.ExecuteOne("Class.NodeList");
        this.ExecuteOne("Class.TaskKindList");
        this.ExecuteOne("Infra.StatBrushKind");
        this.ExecuteOne("Infra.StatComposite");
        this.ExecuteOne("Infra.StatGradientKind");
        this.ExecuteOne("Infra.StatGradientSpread");
        this.ExecuteOne("Infra.StatImageFormat");
        this.ExecuteOne("Infra.StatNetworkCase");
        this.ExecuteOne("Infra.StatNetworkPortKind");
        this.ExecuteOne("Infra.StatNetworkStatus");
        this.ExecuteOne("Infra.StatPenCap");
        this.ExecuteOne("Infra.StatPenJoin");
        this.ExecuteOne("Infra.StatPenKind");
        this.ExecuteOne("Infra.StatStorageMode");
        this.ExecuteOne("Infra.StatStorageStatus");
        this.ExecuteOne("Infra.StatStreamKind");
        this.ExecuteOne("Infra.StatTextAlign");
        this.ExecuteOne("Infra.StatTextEncodeKind");
        this.ExecuteOne("Infra.StatTextWrap");
        this.ExecuteOne("Infra.StatThreadCase");
        this.ExecuteOne("VSCode.GrammarGen");
        this.ExecuteOne("PrudateSourceGen");
        this.ExecuteOne("ReferBinaryGen");

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