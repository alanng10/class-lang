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

    protected override ListEntry GetItemEntry(String line)
    {
        Array k;
        k = this.TextLimit(this.TA(line), this.TB(this.S(" ")));

        ListEntry a;
        a = new ListEntry();
        a.Init();
        a.Index = k.GetAt(0);
        a.Value = k.GetAt(1);
        return a;
    }
}