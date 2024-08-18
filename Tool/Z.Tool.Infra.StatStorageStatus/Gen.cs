namespace Z.Tool.Infra.StatStorageStatus;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("StorageStatus");
        this.ScopeName = this.S("QFileDevice");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListStorageStatus.txt");

        return base.Execute();
    }
}