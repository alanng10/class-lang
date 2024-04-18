namespace Z.Tool.StatNetworkCaseSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "NetworkCase";



        this.ScopeName = "QAbstractSocket";



        this.ValuePostfix = "State";



        this.ValueOffset = " + 1";




        this.ItemListFileName = "ItemListNetworkCase.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}