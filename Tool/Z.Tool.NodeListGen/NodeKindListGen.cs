namespace Z.Tool.NodeListGen;

public class NodeKindListGen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Saber.Node");
        this.ClassName = this.S("NodeKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("NodeKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ClassFileName = this.S("ToolData/Saber/ClassNodeKind.txt");
        this.InitMethodFileName = this.S("ToolData/Saber/InitMaideNodeKind.txt");
        this.AddMethodFileName = this.S("ToolData/Saber/AddMaideNodeKind.txt");
        this.OutputFilePath = this.S("../../Saber/Saber.Node/NodeKindList.cs");
        return true;
    }

    public virtual Table ClassTable { get; set; }

    protected override bool ExecuteItemList()
    {   
        this.ItemTable = this.ToolInfra.TableCreateStringLess();

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        
        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            String a;
            a = varClass.Name;

            TableEntry entry;
            entry = this.GetItemEntry(a);

            this.ItemTable.Add(entry);
        }
        return true;
    }

    protected override TableEntry GetItemEntry(String line)
    {
        String index;
        index = line;

        Text k;
        k = this.TextCreate(line);

        Text ka;
        ka = this.TextCreate(this.S("Count"));

        if (this.TextSame(k, ka))
        {
            index = this.AddClear().AddS("Item").Add(line).AddResult();
        }

        TableEntry a;
        a = new TableEntry();
        a.Init();
        a.Index = index;
        a.Value = line;
        return a;
    }

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        String aa;
        aa = (String)value;

        this
            .AddS("AddItem")
            .AddS("(")
            .AddS("\"").Add(aa).AddS("\"").AddS(",").AddS(" ")
            .AddS("new").AddS(" ").Add(aa).AddS("(").AddS(")").AddS(",").AddS(" ")
            .AddS("new").AddS(" ").Add(aa).AddS("NewState").AddS("(").AddS(")").AddS(",").AddS(" ")
            .AddS("new").AddS(" ").Add(aa).AddS("NodeState").AddS("(").AddS(")").AddS(",").AddS(" ")
            .AddS("new").AddS(" ").Add(aa).AddS("CreateSetState").AddS("(").AddS(")")
            .AddS(")")
            ;
        return true;
    }
}