namespace Z.Tool.System.NetworkPortKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "System.Network";
        this.ClassName = "PortKindList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "PortKind";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "NetworkPortKind";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}