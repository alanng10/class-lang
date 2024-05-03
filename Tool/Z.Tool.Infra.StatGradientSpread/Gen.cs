namespace Z.Tool.StatGradientSpreadSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "GradientSpread";



        this.ScopeName = "QGradient";



        this.ValuePostfix = "Spread";


        
        this.ValueOffset = " + 1";




        this.ItemListFileName = "ToolData/ItemListGradientSpread.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}