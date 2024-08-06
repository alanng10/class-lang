namespace Z.Tool.Avalon.StorageStatusList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Storage";
        this.ClassName = "StatusList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "Status";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "StorageStatus";
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = "ToolData/AddMethodStorageStatus.txt";
        this.InitMethodFileName = "ToolData/InitMethod.txt";
        return true;
    }

    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        sb.Append("AddItem").Append("(").Append(")");
        return true;
    }
}