namespace Z.Tool.Avalon.NetworkCaseList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Avalon.Network";
        this.ClassName = "CaseList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "Case";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "NetworkCase";
        this.ItemListFileName = this.GetStatItemListFileName();
        this.AddMethodFileName = "ToolData/AddMethodNetworkCase.txt";
        this.InitMethodFileName = "ToolData/InitMethod.txt";
        return true;
    }

    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        sb.Append("AddItem").Append("(").Append(")");
        return true;
    }
}