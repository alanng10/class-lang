namespace Z.Tool.Infra.StatComposite;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "Composite";
        this.ScopeName = "QPainter";
        this.ValuePrefix = "CompositionMode_";
        this.ValueOffset = " + 1";
        this.ItemListFileName = "ToolData/ItemListComposite.txt";
        int o;        
        o = base.Execute();
        return o;
    }
}