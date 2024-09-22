namespace Z.Tool.Infra.StatPolateSpread;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("PolateSpread");
        this.ScopeName = this.S("QGradient");
        this.ValuePostfix = this.S("Spread");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListPolateSpread.txt");

        return base.Execute();
    }
}