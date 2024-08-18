namespace Z.Tool.Infra.StatStorageMode;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("StorageMode");
        this.ScopeName = this.S("QIODeviceBase");
        this.ValuePostfix = this.S("Only");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListStorageMode.txt");

        return base.Execute();
    }
}