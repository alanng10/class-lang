namespace Z.Tool.System.NetworkStatusList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "System.Network";
        this.ClassName = "StatusList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "Status";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "NetworkStatus";
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = "ToolData/System/AddMaideNetworkStatus.txt";
        this.InitMethodFileName = "ToolData/System/InitMaide.txt";
        return true;
    }

    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        sb.Append("AddItem").Append("(").Append(")");
        return true;
    }
}