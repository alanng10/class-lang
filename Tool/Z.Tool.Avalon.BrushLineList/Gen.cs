namespace Z.Tool.Avalon.BrushLineList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Draw";
        this.ClassName = "BrushLineList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "BrushLine";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "BrushLine";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}