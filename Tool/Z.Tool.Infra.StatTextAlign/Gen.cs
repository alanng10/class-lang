namespace Z.Tool.StatTextAlignSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "TextAlign";



        this.ValuePrefix = "Align";




        this.ItemListFileName = "ToolData/ItemListTextAlign.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}