namespace Z.Tool.Infra.StatNetworkCase;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "NetworkCase";



        this.ScopeName = "QAbstractSocket";



        this.ValuePostfix = "State";



        this.ValueOffset = " + 1";




        this.ItemListFileName = "ToolData/ItemListNetworkCase.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}