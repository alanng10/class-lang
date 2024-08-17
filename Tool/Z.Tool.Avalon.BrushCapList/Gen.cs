namespace Z.Tool.Avalon.BrushCapList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = this.S("Avalon.Draw");
        this.ClassName = this.S("BrushCapList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("BrushCap");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("BrushCap");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}