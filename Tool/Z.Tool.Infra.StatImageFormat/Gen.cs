namespace Z.Tool.StatImageFormatSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "ImageFormat";



        this.ScopeName = "";



        this.ScopeSeparator = "";




        this.ItemListFileName = "ToolData/ItemListImageFormat.txt";


        this.MethodFileName = "ToolData/MethodImageFormat.txt";




        int o;

        o = base.Execute();


        return o;
    }




    protected override string GetItemMethod(string method, Iter iter, int index)
    {
        return base.GetItemMethod(method, iter, index + 1);
    }




    protected override string GetShareVarList()
    {
        return "";
    }
}