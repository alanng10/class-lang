namespace Z.Tool.Mirai.BrushKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Mirai.Draw");
        this.ClassName = this.S("BrushKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("BrushKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("BrushKind");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}