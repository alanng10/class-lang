namespace Z.Tool.StatTextEncodeKindSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "TextEncodeKind";




        this.ScopeName = "QStringConverter";




        this.ValueOffset = " + 1";




        this.ItemListFileName = "ToolData/ItemListTextEncodeKind.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}