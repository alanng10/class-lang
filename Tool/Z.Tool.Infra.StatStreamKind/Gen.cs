namespace Z.Tool.Infra.StatStreamKind;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("StreamKind");
        this.ScopeName = this.S("");
        this.ScopeSeparator = this.S("");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListStreamKind.txt");
        this.MethodFileName = this.S("ToolData/Infra/MethodStreamKind.txt");

        return base.Execute();
    }

    protected override String GetItemMethod(String method, Iter iter, long index)
    {
        return base.GetItemMethod(method, iter, index + 1);
    }

    protected override String GetShareVarList()
    {
        return this.S("");
    }
}