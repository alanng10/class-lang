namespace Z.Tool.System.TextEncodeKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "System.Text";
        this.ClassName = "EncodeKindList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "EncodeKind";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "TextEncodeKind";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}