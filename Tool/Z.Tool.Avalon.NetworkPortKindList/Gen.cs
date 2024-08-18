namespace Z.Tool.Avalon.NetworkPortKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Avalon.Network");
        this.ClassName = this.S("PortKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("PortKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("NetworkPortKind");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}