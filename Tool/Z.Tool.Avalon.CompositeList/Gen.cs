namespace Z.Tool.Avalon.CompositeList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Draw";
        this.ClassName = "CompositeList";
        this.BaseClassName = "Any";
        this.ItemClassName = "Composite";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "Composite";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}