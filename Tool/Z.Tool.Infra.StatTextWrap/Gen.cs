namespace Z.Tool.StatTextWrapSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "TextWrap";



        this.ValuePrefix = "Text";



        this.ItemListFileName = "ToolData/ItemListTextWrap.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}