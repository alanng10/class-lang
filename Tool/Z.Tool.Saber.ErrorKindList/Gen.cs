namespace Z.Tool.Saber.ErrorKindList;

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

        this.Module = this.AddClear().AddS("Saber.").Add(k).AddResult();
        this.ClassName = this.S("ErrorKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("ErrorKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ClassFileName = this.S("ToolData/Class/ClassErrorKind.txt");
        this.InitMethodFileName = this.S("ToolData/Class/InitMaideErrorKind.txt");
        this.ItemListFileName = this.AddClear().AddS("ToolData/Class/ItemListErrorKind").Add(k).AddS(".txt").AddResult();
        this.AddMethodFileName = this.S("ToolData/Class/AddMaideErrorKind.txt");
        this.OutputFilePath = this.AddClear().AddS("../../Saber/Saber.").Add(k).AddS("/ErrorKindList.cs").AddResult();
        base.Execute();
        return true;
    }

    protected override TableEntry GetItemEntry(String line)
    {
        String index;
        index = line;
        String text;        
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

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        Value a;
        a = (Value)value;

        this.AddS("AddItem")
            .AddS("(")
            .AddS("\"").Add(a.Text).AddS("\"")
            .AddS(")");
        return true;
    }
}