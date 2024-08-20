namespace Z.Tool.Class.CountList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Class.Infra");
        this.ClassName = this.S("CountList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Count");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ItemListFileName = "ToolData/ItemListCount.txt";
        this.AddMethodFileName = "ToolData/AddMethodCount.txt";
        this.OutputFilePath = "../../Class/Class.Infra/CountList.cs";
        return true;
    }
}