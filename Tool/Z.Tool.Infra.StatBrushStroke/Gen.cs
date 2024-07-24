namespace Z.Tool.Infra.StatPenKind;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "BrushStroke";
        
        this.ValuePostfix = "Line";

        this.ItemListFileName = "ToolData/ItemListBrushStroke.txt";

        int o;        
        o = base.Execute();
        return o;
    }
}