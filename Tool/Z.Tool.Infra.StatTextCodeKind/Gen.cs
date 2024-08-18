namespace Z.Tool.Infra.StatTextCodeKind;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("TextCodeKind");
        this.ScopeName = this.S("");
        this.ScopeSeparator = this.S("");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListTextCodeKind.txt");
        this.MethodFileName = this.S("ToolData/Infra/MaideTextCodeKind.txt");

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