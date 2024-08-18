namespace Z.Tool.Infra.StatBrushKind;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("BrushKind");
        this.ItemListFileName = this.S("ToolData/Infra/ItemListBrushKind.txt");
        this.MethodFileName = this.S("ToolData/Infra/MaideBrushKind.txt");
        
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