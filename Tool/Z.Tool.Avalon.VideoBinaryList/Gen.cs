namespace Z.Tool.Avalon.VideoBinaryList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Avalon.Video");
        this.ClassName = this.S("VideoBinaryList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("VideoBinary");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("ImageBinary");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}