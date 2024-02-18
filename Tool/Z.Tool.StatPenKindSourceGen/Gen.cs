namespace Z.Tool.StatPenKindSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "PenKind";

        
        
        this.ValuePostfix = "Line";
        


        this.ItemListFileName = "ItemListPenKind.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}