namespace Z.Tool.Infra.StatImageFormat;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("ImageFormat");
        this.ScopeName = this.S("");
        this.ScopeSeparator = this.S("");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListImageFormat.txt");
        this.MethodFileName = this.S("ToolData/Infra/MethodImageFormat.txt");

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