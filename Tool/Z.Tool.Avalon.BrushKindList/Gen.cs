namespace Z.Tool.Avalon.BrushKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = this.S("Avalon.Draw");
        this.ClassName = this.S("BrushKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = "Any";
        this.ItemClassName = "BrushKind";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "BrushKind";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}