namespace Z.Tool.Infra.StatBrushKind;

class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "BrushKind";
        this.ItemListFileName = "ToolData/ItemListBrushKind.txt";
        this.MethodFileName = "ToolData/MaideBrushKind.txt";
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