namespace Z.Tool.Avalon.BrushJoinList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Draw";
        this.ClassName = "BrushJoinList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "BrushJoin";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "BrushJoin";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}