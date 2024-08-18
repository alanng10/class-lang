namespace Z.Tool.Avalon.TextCodeKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Avalon.Text");
        this.ClassName = this.S("CodeKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("CodeKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("TextEncodeKind");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}