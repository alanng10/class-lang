namespace Z.Infra.ListSourceGen;

public class AvalonGen : Gen
{
    public override bool Init()
    {
        base.Init();
        this.ClassFileName = "ToolData/Avalon/Class.txt";
        this.InitMethodFileName = "ToolData/Avalon/InitMaide.txt";
        this.AddMethodFileName = "ToolData/Avalon/AddMaide.txt";
        this.ArrayCompListFileName = "ToolData/Avalon/ArrayCompList.txt";
        this.ItemListFileName = "ToolData/Avalon/ItemList.txt";
        return true;
    }

    protected override bool AppendInitField(StringBuilder sb, string index, object value)
    {
        this.ToolInfra.AppendIndent(sb, 2);

        sb.Append("this").Append(".").Append(index).Append(" ").Append("=").Append(" ").Append("this").Append(".");

        this.AppendInitFieldAddItem(sb, index, value);

        sb.Append(";").Append(this.ToolInfra.NewLine);
        return true;
    }

    protected override bool AppendField(StringBuilder sb, string item)
    {
        this.ToolInfra.AppendIndent(sb, 1);
        sb
            .Append("public").Append(" ").Append("virtual").Append(" ")
            .Append(this.ItemClassName).Append(" ").Append(item).Append(" ")
            .Append("{").Append(" ").Append("get").Append(";").Append(" ").Append("set").Append(";").Append(" ").Append("}")
            .Append(this.ToolInfra.NewLine);
        return true;
    }
}