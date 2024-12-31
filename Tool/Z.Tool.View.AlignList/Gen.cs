namespace Z.Tool.View.AlignList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("View.Draw");
        this.ClassName = this.S("AlignList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Align");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ItemListFileName = this.S("ToolData/View/ItemListAlign.txt");
        this.AddMethodFileName = this.S("ToolData/View/AddMaideAlign.txt");
        this.OutputFilePath = this.S("../../View/View.Draw/AlignList.cl");
        return true;
    }
}