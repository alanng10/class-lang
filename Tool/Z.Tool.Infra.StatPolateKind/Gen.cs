namespace Z.Tool.Infra.StatPolateKind;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("PolateKind");
        this.ScopeName = this.S("QGradient");
        this.ValuePostfix = this.S("Gradient");
        this.ValueOffset = this.S(" + 1");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListPolateKind.txt");

        return base.Execute();
    }
}