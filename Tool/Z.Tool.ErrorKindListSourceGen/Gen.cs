namespace Z.Tool.ErrorKindListSourceGen;

public class Gen : SourceGen
{
    public override int Execute()
    {
        this.ExecuteOne("Node");
        this.ExecuteOne("Check");
        return 0;
    }

    protected virtual bool ExecuteOne(string name)
    {
        this.Namespace = "Class." + name;
        this.ClassName = "ErrorKindList";
        this.BaseClassName = "Any";
        this.ItemClassName = "ErrorKind";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.ItemListFileName = "ItemListErrorKind" + name + ".txt";
        this.AddMethodFileName = "AddMethodErrorKind.txt";
        this.OutputFilePath = "../../Class/Class." + name + "/ErrorKindList.cs";
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