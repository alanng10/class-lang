namespace Z.Tool.Saber.IndexList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Saber.Infra");
        this.ClassName = this.S("IndexList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Index");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ClassFileName = this.S("ToolData/Saber/ClassIndex.txt");
        this.InitMethodFileName = this.S("ToolData/Saber/InitMaideIndex.txt");
        this.ItemListFileName = this.S("ToolData/Saber/ItemListIndex.txt");
        this.AddMethodFileName = this.S("ToolData/Saber/AddMaideIndex.txt");
        this.OutputFilePath = this.S("../../Saber/Saber.Infra/IndexList.cs");
        return true;
    }

    protected override TableEntry GetItemEntry(String line)
    {
        String index;
        index = line;

        String indexA;
        indexA = index;

        if (this.TextSame(this.TA(indexA), this.TB(this.S("This"))) |
            this.TextSame(this.TA(indexA), this.TB(this.S("Get")))
        )
        {
            indexA = this.AddClear().AddS("Item").Add(indexA).AddResult();
        }

        Text ka;
        ka = this.TextAlphaSite(this.TA(index));

        String text;        
        text = this.StringCreate(ka);

        Value value;
        value = new Value();
        value.Init();
        value.Text = text;

        TableEntry entry;
        entry = new TableEntry();
        entry.Init();
        entry.Index = indexA;
        entry.Value = value;
        return entry;
    }

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        Value a;
        a = value as Value;

        this.AddS("AddItem")
            .AddS("(")
            .AddS("\"").Add(a.Text).AddS("\"")
            .AddS(")");
        return true;
    }
}