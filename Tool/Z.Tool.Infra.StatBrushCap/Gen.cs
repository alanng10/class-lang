namespace Z.Tool.Infra.StatBrushCap;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("BrushCap");

        this.ValuePostfix = this.S("Cap");

        this.ValueOffset = this.S(" + 1");

        this.ItemListFileName = this.S("ToolData/Infra/ItemListBrushCap.txt");

        long o;
        o = base.Execute();
        return o;
    }
}