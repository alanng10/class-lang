namespace Z.Tool.View.PolateSpreadList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("View.Draw");
        this.ClassName = this.S("PolateSpreadList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("PolateSpread");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("PolateSpread");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}