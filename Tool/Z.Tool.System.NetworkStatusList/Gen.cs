namespace Z.Tool.System.NetworkStatusList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = this.S("System.Network");
        this.ClassName = this.S("StatusList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Status");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("NetworkStatus");
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = this.S("ToolData/System/AddMaideNetworkStatus.txt");
        this.InitMethodFileName = this.S("ToolData/System/InitMaide.txt");
        return true;
    }

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        this.AddS("AddItem").AddS("(").AddS(")");
        return true;
    }
}