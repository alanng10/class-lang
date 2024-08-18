namespace Z.Tool.Infra.StatBrushLine;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("BrushLine");
        
        this.ValuePostfix = this.S("Line");

        this.ItemListFileName = this.S("ToolData/Infra/ItemListBrushLine.txt");

        return base.Execute();
    }
}