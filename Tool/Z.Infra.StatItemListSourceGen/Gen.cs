namespace Z.Infra.StatItemListSourceGen;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.AddMethodFileName = "ToolData/System/AddMaideStatItem.txt";
        this.InitMethodFileName = "ToolData/System/InitMaideStatItem.txt";
        return true;
    }

    public override int Execute()
    {
        this.OutputFilePath = this.GetOutputFilePath();
        return base.Execute();
    }

    protected virtual string StatItemClassName { get; set; }

    protected virtual string GetStatItemListFileName()
    {
        return "ToolData/ItemList" + this.StatItemClassName + ".txt";
    }

    protected virtual string GetOutputFilePath()
    {
        return "../../../System/" + this.Namespace + "/" + this.ClassName + ".cla";
    }

    protected override TableEntry GetItemEntry(string line)
    {
        string name;
        name = line;
        string value;
        value = line;

        int uu;
        uu = line.IndexOf(' ');
        if (!(uu < 0))
        {
            name = line.Substring(0, uu);
            value = line.Substring(uu + 1);
        }

        TableEntry a;
        a = new TableEntry();
        a.Init();
        a.Index = name;
        a.Value = value;
        return a;
    }

    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        sb.Append("AddItem")
            .Append("(")
            .Append("extern.Stat_" + this.StatItemClassName + index).Append("(").Append("stat").Append(")")
            .Append(")");
        return true;
    }
}