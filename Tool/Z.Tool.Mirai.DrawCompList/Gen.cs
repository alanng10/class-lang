namespace Z.Tool.Mirai.DrawCompList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Mirai.Draw");
        this.ClassName = this.S("CompList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Comp");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("Comp");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}