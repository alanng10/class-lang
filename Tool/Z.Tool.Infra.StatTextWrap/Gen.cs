namespace Z.Tool.Infra.StatTextWrap;





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