namespace Z.Tool.Infra.StatBrushKind;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "BrushKind";
        this.ValuePostfix = "Pattern";
        this.ItemListFileName = "ToolData/ItemListBrushKind.txt";
        int o;
        o = base.Execute();
        return o;
    }
}