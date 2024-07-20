namespace Z.Tool.Avalon.CompList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Draw";
        this.ClassName = "CompList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "Comp";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "Composite";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}