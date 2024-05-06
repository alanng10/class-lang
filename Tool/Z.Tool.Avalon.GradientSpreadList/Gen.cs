namespace Z.Tool.Avalon.GradientSpreadList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Draw";
        this.ClassName = "GradientSpreadList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "GradientSpread";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "GradientSpread";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}