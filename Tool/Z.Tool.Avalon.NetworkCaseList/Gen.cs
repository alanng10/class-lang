namespace Z.Tool.Avalon.NetworkCaseList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Avalon.Network");
        this.ClassName = this.S("CaseList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Case");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("NetworkCase");
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = this.S("ToolData/Avalon/AddMaideNetworkCase.txt");
        this.InitMethodFileName = this.S("ToolData/Avalon/InitMaide.txt");
        return true;
    }

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        this.AddS("AddItem").AddS("(").AddS(")");
        return true;
    }
}