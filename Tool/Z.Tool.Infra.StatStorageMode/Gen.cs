namespace Z.Tool.StatStorageModeSourceGen;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "StorageMode";



        this.ScopeName = "QIODeviceBase";
        


        this.ValuePostfix = "Only";



        this.ItemListFileName = "ItemListStorageMode.txt";




        int o;
        
        o = base.Execute();


        return o;
    }
}