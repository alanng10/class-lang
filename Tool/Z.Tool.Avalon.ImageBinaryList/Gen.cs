namespace Z.Tool.Avalon.ImageBinaryList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Avalon.Draw");
        this.ClassName = this.S("ImageBinaryList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("ImageBinary");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("ImageBinary");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}