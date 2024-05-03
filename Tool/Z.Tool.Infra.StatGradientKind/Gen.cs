namespace Z.Tool.StatGradientKindSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "GradientKind";



        this.ScopeName = "QGradient";



        this.ValuePostfix = "Gradient";


        
        this.ValueOffset = " + 1";




        this.ItemListFileName = "ToolData/ItemListGradientKind.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}