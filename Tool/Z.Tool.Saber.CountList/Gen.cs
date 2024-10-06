namespace Z.Tool.Saber.CountList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Saber.Infra");
        this.ClassName = this.S("CountList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Count");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ItemListFileName = this.S("ToolData/Class/ItemListCount.txt");
        this.AddMethodFileName = this.S("ToolData/Class/AddMaideCount.txt");
        this.OutputFilePath = this.S("../../Saber/Saber.Infra/CountList.cs");
        return true;
    }
}