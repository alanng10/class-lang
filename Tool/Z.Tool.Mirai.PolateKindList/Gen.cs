namespace Z.Tool.Mirai.PolateKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Mirai.Draw");
        this.ClassName = this.S("PolateKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("PolateKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("PolateKind");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}