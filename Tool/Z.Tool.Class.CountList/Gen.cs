namespace Z.Tool.Class.CountList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Class.Infra";
        this.ClassName = "CountList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "Count";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.ItemListFileName = "ToolData/ItemListCount.txt";
        this.AddMethodFileName = "ToolData/AddMethodCount.txt";
        this.OutputFilePath = "../../Class/Class.Infra/CountList.cs";
        return true;
    }
}