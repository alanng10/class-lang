namespace Z.Tool.Avalon.NetworkPortKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Network";
        this.ClassName = "PortKindList";
        this.BaseClassName = "Any";
        this.ItemClassName = "PortKind";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "NetworkPortKind";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}