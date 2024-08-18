namespace Z.Tool.System.NetworkCaseList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("System.Network");
        this.ClassName = this.S("CaseList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Case");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("NetworkCase");
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = this.S("ToolData/System/AddMaideNetworkCase.txt");
        this.InitMethodFileName = this.S("ToolData/System/InitMaide.txt");
        return true;
    }

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        this.AddS("AddItem").AddS("(").AddS(")");
        return true;
    }
}