namespace Z.Tool.Infra.StatThreadCase;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("ThreadCase");
        this.ScopeName = this.S("");
        this.ScopeSeparator = this.S("");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListThreadCase.txt");
        this.MethodFileName = this.S("ToolData/Infra/MaideThreadCase.txt");

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