namespace Z.Tool.Avalon.PenCapList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Draw";
        this.ClassName = "PenCapList";
        this.BaseClassName = "Any";
        this.ItemClassName = "PenCap";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "PenCap";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}