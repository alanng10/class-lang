namespace Z.Tool.Infra.StatBrushJoin;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("BrushJoin");

        this.ValuePostfix = this.S("Join");

        this.ValueOffset = this.S(" + 1");

        this.ItemListFileName = this.S("ToolData/Infra/ItemListBrushJoin.txt");

        return base.Execute();
    }
}