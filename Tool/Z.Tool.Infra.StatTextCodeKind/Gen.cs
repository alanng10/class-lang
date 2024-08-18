namespace Z.Tool.Infra.StatTextCodeKind;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "TextCodeKind";

        this.ScopeName = "";

        this.ScopeSeparator = "";

        this.ItemListFileName = "ToolData/ItemListTextEncodeKind.txt";

        this.MethodFileName = "ToolData/MaideTextEncodeKind.txt";

        int o;
        o = base.Execute();

        return o;
    }

    protected override string GetItemMethod(string method, Iter iter, int index)
    {
        return base.GetItemMethod(method, iter, index + 1);
    }

    protected override string GetShareVarList()
    {
        return "";
    }
}