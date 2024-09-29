namespace Z.Tool.Avalon.TuneCompList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Avalon.Tune");
        this.ClassName = this.S("CompList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Comp");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ItemListFileName = this.S("ToolData/Avalon/ItemListTuneComp.txt");
        this.AddMethodFileName = this.S("ToolData/Avalon/AddMaideTuneComp.txt");
        this.OutputFilePath = this.S("../../Avalon/Avalon.Tune/CompList.cs");
        return true;
    }
}