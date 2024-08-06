namespace Z.Infra.ListSourceGen;

public class AvalonGen : Gen
{
    public override bool Init()
    {
        base.Init();
        this.ClassFileName = "ToolData/Avalon/Class.txt";
        this.InitMethodFileName = "ToolData/Avalon/InitMethod.txt";
        this.AddMethodFileName = "ToolData/Avalon/AddMethod.txt";
        this.ArrayCompListFileName = "ToolData/Avalon/ArrayCompList.txt";
        this.ItemListFileName = "ToolData/Avalon/ItemList.txt";
        return true;
    }
}