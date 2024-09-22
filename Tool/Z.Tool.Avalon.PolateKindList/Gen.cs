namespace Z.Tool.Avalon.GradientKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Avalon.Draw");
        this.ClassName = this.S("GradientKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("GradientKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("GradientKind");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}