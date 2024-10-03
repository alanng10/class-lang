namespace Z.Tool.Mirai.BrushLineList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Mirai.Draw");
        this.ClassName = this.S("BrushLineList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("BrushLine");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("BrushLine");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}