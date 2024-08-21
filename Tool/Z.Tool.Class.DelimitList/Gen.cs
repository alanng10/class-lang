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
        this.ClassFileName = this.S("ToolData/Class/ClassDelimit.txt");
        this.InitMethodFileName = this.S("ToolData/Class/InitMaideDelimit.txt");
        this.ItemListFileName = this.S("ToolData/Class/ItemListDelimit.txt");
        this.AddMethodFileName = this.S("ToolData/Class/AddMaideDelimit.txt");
        this.OutputFilePath = this.S("../../Class/Class.Infra/DelimitList.cs");
        return true;
    }

    protected override TableEntry GetItemEntry(String line)
    {
        Text kka;
        kka = this.TextCreate(this.S(" "));

        Text k;
        k = this.TextCreate(line);

        Array array;
        array = this.TextSplit(k, kka);
        
        Text ka;
        Text kb;
        ka = (Text)array.GetAt(0);
        kb = (Text)array.GetAt(1);

        String index;
        index = this.StringCreate(ka);

        String text;
        text = this.StringCreate(kb);

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