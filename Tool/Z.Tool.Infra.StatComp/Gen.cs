namespace Z.Tool.Infra.StatComp;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "Comp";
        this.ScopeName = "QPainter";
        this.ValuePrefix = "CompositionMode_";
        this.ValueOffset = " + 1";
        this.ItemListFileName = "ToolData/ItemListComp.txt";
        int o;        
        o = base.Execute();
        return o;
    }
}