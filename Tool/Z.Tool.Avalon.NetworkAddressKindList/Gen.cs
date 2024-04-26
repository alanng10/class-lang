namespace Z.Tool.Avalon.NetworkAddressKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Network";
        this.ClassName = "AddressKindList";
        this.BaseClassName = "Any";
        this.ItemClassName = "AddressKind";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "NetworkAddressKind";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}