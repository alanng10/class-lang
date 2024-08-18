namespace Z.Tool.Infra.StatBrushCap;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = this.S("BrushCap");

        this.ValuePostfix = this.S("Cap");

        this.ValueOffset = this.S(" + 1");

        this.ItemListFileName = this.S("ToolData/Infra/ItemListBrushCap.txt");

        int o;
        o = base.Execute();
        return o;
    }
}