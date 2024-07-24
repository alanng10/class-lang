namespace Z.Tool.Infra.StatBrushLine;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "BrushLine";
        
        this.ValuePostfix = "Line";

        this.ItemListFileName = "ToolData/ItemListBrushLine.txt";

        int o;        
        o = base.Execute();
        return o;
    }
}