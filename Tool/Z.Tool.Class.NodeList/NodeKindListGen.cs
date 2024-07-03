namespace Z.Tool.Class.NodeList;

public class NodeKindListGen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "Class.Node";
        this.ClassName = "NodeKindList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "NodeKind";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.AddMethodFileName = "ToolData/AddMethodNodeKind.txt";
        this.OutputFilePath = "../../Class/Class.Node/NodeKindList.cs";
        return true;
    }

    public virtual Table ClassTable { get; set; }

    protected override bool ExecuteItemList()
    {
        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();

        StringCompare compare;
        compare = new StringCompare();
        compare.CharCompare = charCompare;
        compare.Init();
        
        this.ItemTable = new Table();
        this.ItemTable.Compare = compare;
        this.ItemTable.Init();

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        
        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            string a;
            a = varClass.Name;

            TableEntry entry;
            entry = this.GetItemEntry(a);

            this.ItemTable.Add(entry);
        }
        return true;
    }

    protected override TableEntry GetItemEntry(string line)
    {
        string index;
        index = line;
        if (index == "Count")
        {
            index = "Item" + index;
        }
        TableEntry a;
        a = new TableEntry();
        a.Init();
        a.Index = index;
        a.Value = line;
        return a;
    }

    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        string aa;
        aa = value.ToString();
        string newState;
        newState = aa + "NewState";
        string nodeState;
        nodeState = aa + "NodeState";
        string createOperateState;
        createOperateState = aa + "CreateOperateState";
        sb
            .Append("AddItem")
            .Append("(")
            .Append("\"").Append(aa).Append("\"").Append(",").Append(" ")
            .Append("new").Append(" ").Append(aa).Append("(").Append(")").Append(",").Append(" ")
            .Append("new").Append(" ").Append(newState).Append("(").Append(")").Append(",").Append(" ")
            .Append("new").Append(" ").Append(nodeState).Append("(").Append(")").Append(",").Append(" ")
            .Append("new").Append(" ").Append(createOperateState).Append("(").Append(")")
            .Append(")")
            ;
        return true;
    }
}