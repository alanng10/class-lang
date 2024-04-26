namespace Z.Tool.Avalon.NetworkStatusList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Network";
        this.ClassName = "StatusList";
        this.BaseClassName = "Any";
        this.ItemClassName = "Status";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "NetworkStatus";
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = "AddMethodNetworkStatus.txt";
        this.InitMethodFileName = "InitMethod.txt";
        return true;
    }

    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        sb.Append("AddItem").Append("(").Append(")");
        return true;
    }
}