namespace Z.Infra.StatItemListSourceGen;

public class AvalonGen : AvalonSourceGen
{
    public override bool Init()
    {
        base.Init();
        this.AddMethodFileName = this.S("ToolData/Avalon/AddMaideStatItem.txt");
        this.InitMethodFileName = this.S("ToolData/Avalon/InitMaideStatItem.txt");
        return true;
    }

    public override int Execute()
    {
        this.OutputFilePath = this.GetOutputFilePath();
        return base.Execute();
    }

    protected virtual String StatItemClassName { get; set; }

    protected virtual String GetStatItemListFileName()
    {
        return this.AddClear().AddS("ToolData/ItemList").Add(this.StatItemClassName).AddS(".txt").AddResult();
    }

    protected virtual String GetOutputFilePath()
    {
        return this.AddClear().AddS("../../Avalon/").Add(this.Namespace).AddS("/").Add(this.ClassName).AddS(".cs").AddResult();
    }

    protected override TableEntry GetItemEntry(String line)
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
            .Append("Extern.Stat_" + this.StatItemClassName + index).Append("(").Append("stat").Append(")")
            .Append(")");
        return true;
    }
}