namespace Z.Tool.Infra.StatComp;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("Comp");
        this.ScopeName = this.S("QPainter");
        this.ValuePrefix = this.S("CompositionMode_");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListComp.txt");

        return base.Execute();
    }
}