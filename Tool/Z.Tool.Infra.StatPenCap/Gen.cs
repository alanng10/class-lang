namespace Z.Tool.StatPenCapSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "PenCap";



        this.ValuePostfix = "Cap";


        
        this.ValueOffset = " + 1";




        this.ItemListFileName = "ToolData/ItemListPenCap.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}