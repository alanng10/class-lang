namespace Z.Tool.View.SlashCapList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("View.Draw");
        this.ClassName = this.S("SlashCapList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("SlashCap");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("SlashCap");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}