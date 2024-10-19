namespace Z.Tool.Mirai.SlashJoinList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Mirai.Draw");
        this.ClassName = this.S("SlashJoinList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("SlashJoin");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("SlashJoin");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}