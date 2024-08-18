namespace Z.Tool.Infra.StatImageBinary;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("ImageBinary");
        this.ScopeName = this.S("");
        this.ScopeSeparator = this.S("");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListImageBinary.txt");
        this.MethodFileName = this.S("ToolData/Infra/MaideImageBinary.txt");

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