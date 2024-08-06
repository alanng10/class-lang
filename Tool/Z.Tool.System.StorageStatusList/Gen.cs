namespace Z.Tool.System.StorageStatusList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "System.Storage";
        this.ClassName = "StatusList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "Status";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "StorageStatus";
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = "ToolData/System/AddMaideStorageStatus.txt";
        this.InitMethodFileName = "ToolData/System/InitMaide.txt";
        return true;
    }

    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        sb.Append("AddItem").Append("(").Append(")");
        return true;
    }
}