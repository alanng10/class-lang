namespace Z.Tool.System.GradientSpreadList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("System.Draw");
        this.ClassName = this.S("GradientSpreadList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("GradientSpread");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("GradientSpread");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}