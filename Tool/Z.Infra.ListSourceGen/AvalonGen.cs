namespace Z.Infra.ListSourceGen;

public class AvalonGen : Gen
{
    public override bool Init()
    {
        base.Init();
        this.ClassFileName = this.S("ToolData/Avalon/Class.txt");
        this.InitMethodFileName = this.S("ToolData/Avalon/InitMaide.txt");
        this.AddMethodFileName = this.S("ToolData/Avalon/AddMaide.txt");
        this.ArrayCompListFileName = this.S("ToolData/Avalon/ArrayCompList.txt");
        this.ItemListFileName = this.S("ToolData/Avalon/ItemList.txt");
        return true;
    }

    protected override bool AddInitField(String index, object value)
    {
        this.AddIndent(2);

        this.AddS("this").AddS(".").Add(index).AddS(" ").AddS("=").AddS(" ").AddS("this").AddS(".");

        this.AddInitFieldAddItem(index, value);

        this.AddS(";").Add(this.ToolInfra.NewLine);
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