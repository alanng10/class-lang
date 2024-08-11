namespace Z.Tool.System.BrushCapList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "System.Draw";
        this.ClassName = "BrushCapList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "BrushCap";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "BrushCap";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}