namespace Z.Tool.Avalon.BrushLineList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = this.S("Avalon.Draw");
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