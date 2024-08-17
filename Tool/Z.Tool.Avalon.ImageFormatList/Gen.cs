namespace Z.Tool.Avalon.ImageFormatList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = this.S("Avalon.Draw");
        this.ClassName = this.S("ImageFormatList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("ImageFormat");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.StatItemClassName = this.S("ImageFormat");
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}