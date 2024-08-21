namespace Z.Tool.Class.ErrorKindList;

public class Gen : SourceGen
{
    public override long Execute()
    {
        this.ExecuteOne("Node");
        this.ExecuteOne("Module");
        return 0;
    }

    protected virtual bool ExecuteOne(string name)
    {
        String k;
        k = this.S(name);

        this.Module = this.AddClear().AddS("Class.").Add(k).AddResult();
        this.ClassName = this.S("ErrorKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("ErrorKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ItemListFileName = this.AddClear().AddS("ToolData/Infra/ItemListErrorKind").Add(k).AddS(".txt").AddResult();
        this.AddMethodFileName = this.S("ToolData/Infra/AddMaideErrorKind.txt");
        this.OutputFilePath = this.AddClear().AddS("../../Class/Class.").Add(k).AddS("/ErrorKindList.cs").AddResult();
        base.Execute();
        return true;
    }

    protected override TableEntry GetItemEntry(string line)
    {
        string index;
        index = line;
        string text;        
        text = index;

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