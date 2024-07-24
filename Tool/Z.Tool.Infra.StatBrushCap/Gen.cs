namespace Z.Tool.Infra.StatBrushCap;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "BrushCap";

        this.ValuePostfix = "Cap";

        this.ValueOffset = " + 1";

        this.ItemListFileName = "ToolData/ItemListBrushCap.txt";

        int o;
        o = base.Execute();
        return o;
    }
}