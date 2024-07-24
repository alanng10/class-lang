namespace Z.Tool.Infra.StatBrushJoin;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "BrushJoin";

        this.ValuePostfix = "Join";

        this.ValueOffset = " + 1";

        this.ItemListFileName = "ToolData/ItemListBrushJoin.txt";

        int o;      
        o = base.Execute();
        return o;
    }
}