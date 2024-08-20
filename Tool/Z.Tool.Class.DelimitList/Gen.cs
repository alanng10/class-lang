namespace Z.Tool.Class.DelimitList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Class.Infra");
        this.ClassName = this.S("DelimitList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Delimit");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ItemListFileName = this.S("ToolData/Class/ItemListDelimit.txt");
        this.AddMethodFileName = this.S("ToolData/Class/AddMaideDelimit.txt");
        this.OutputFilePath = this.S("../../Class/Class.Infra/DelimitList.cs");
        return true;
    }

    protected override TableEntry GetItemEntry(String line)
    {
        string[] ua;
        ua = line.Split(' ');

        string index;
        index = ua[0];

        string text;
        text = ua[1];

        Value value;
        value = new Value();
        value.Init();
        value.Text = text;

        TableEntry entry;
        entry = new TableEntry();
        entry.Init();
        entry.Index = index;
        entry.Value = value;
        return entry;
    }

    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        Value a;
        a = (Value)value;
        sb.Append("AddItem")
            .Append("(")
            .Append("\"").Append(a.Text).Append("\"")
            .Append(")");
        return true;
    }
}