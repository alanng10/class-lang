namespace Z.Tool.Avalon.NetworkStatusList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = this.S("Avalon.Network");
        this.ClassName = this.S("StatusList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Status");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("NetworkStatus");
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = this.S("ToolData/Avalon/AddMaideNetworkStatus.txt");
        this.InitMethodFileName = this.S("ToolData/Avalon/InitMaide.txt");
        return true;
    }

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        this.AddS("AddItem").AddS("(").AddS(")");
        return true;
    }
}