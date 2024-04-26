namespace Z.Tool.Avalon.PenJoinList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Draw";
        this.ClassName = "PenJoinList";
        this.BaseClassName = "Any";
        this.ItemClassName = "PenJoin";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "PenJoin";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}