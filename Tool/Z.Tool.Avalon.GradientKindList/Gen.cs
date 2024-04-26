namespace Z.Tool.Avalon.GradientKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Draw";
        this.ClassName = "GradientKindList";
        this.BaseClassName = "Any";
        this.ItemClassName = "GradientKind";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "GradientKind";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}