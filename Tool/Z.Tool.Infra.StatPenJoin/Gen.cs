namespace Z.Tool.StatPenJoinSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "PenJoin";



        this.ValuePostfix = "Join";


        
        this.ValueOffset = " + 1";




        this.ItemListFileName = "ToolData/ItemListPenJoin.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}