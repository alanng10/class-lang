namespace Z.Tool.Infra.StatGradientKind;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("GradientKind");
        this.ScopeName = this.S("QGradient");
        this.ValuePostfix = this.S("Gradient");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListGradientKind.txt");

        return base.Execute();
    }
}