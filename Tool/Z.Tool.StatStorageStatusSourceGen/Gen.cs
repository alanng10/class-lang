namespace Z.Tool.StatStorageStatusSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "StorageStatus";



        this.ScopeName = "QFileDevice";
        



        this.ItemListFileName = "ItemListStorageStatus.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}