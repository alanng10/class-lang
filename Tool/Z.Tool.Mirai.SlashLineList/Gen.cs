namespace Z.Tool.Mirai.SlashLineList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Mirai.Draw");
        this.ClassName = this.S("SlashLineList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("SlashLine");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("SlashLine");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}