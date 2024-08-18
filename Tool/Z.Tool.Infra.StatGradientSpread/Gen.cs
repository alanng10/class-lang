namespace Z.Tool.Infra.StatGradientSpread;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("GradientSpread");
        this.ScopeName = this.S("QGradient");
        this.ValuePostfix = this.S("Spread");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListGradientSpread.txt");

        return base.Execute();
    }
}