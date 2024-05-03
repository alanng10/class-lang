namespace Z.Tool.Infra.StatStorageStatus;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "StorageStatus";



        this.ScopeName = "QFileDevice";
        



        this.ItemListFileName = "ToolData/ItemListStorageStatus.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}