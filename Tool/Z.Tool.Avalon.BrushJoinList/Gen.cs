namespace Z.Tool.Avalon.BrushJoinList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = this.S("Avalon.Draw");
        this.ClassName = this.S("BrushJoinList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("BrushJoin");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("BrushJoin");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}