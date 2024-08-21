namespace Z.Tool.Class.KeywordList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Class.Infra");
        this.ClassName = this.S("KeywordList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Keyword");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ItemListFileName = this.S("ToolData/Class/ItemListKeyword.txt");
        this.AddMethodFileName = this.S("ToolData/Class/AddMaideKeyword.txt");
        this.OutputFilePath = this.S("../../Class/Class.Infra/KeywordList.cs");
        return true;
    }

    protected override TableEntry GetItemEntry(String line)
    {
        string index;
        index = line;

        string aa;
        aa = "Item";

        string k;
        k = index;
        if (k.StartsWith(aa))
        {
            k = k.Substring(aa.Length);
        }

        k = k.ToLower();

        string text;        
        text = k;

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