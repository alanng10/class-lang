namespace Z.Tool.Class.NodeList;






public class NodeKindListGen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Class.Node";


        this.ClassName = "NodeKindList";


        this.BaseClassName = "Any";


        this.ItemClassName = "NodeKind";


        this.ArrayClassName = "Array";




        this.Export = true;





        this.AddMethodFileName = "AddMethodNodeKind.txt";



        this.OutputFilePath = "../../Class/Class.Node/NodeKindList.cs";





        return true;
    }





    public virtual Array ClassArray { get; set; }






    protected override bool ExecuteItemList()
    {
        StringCompare compare;

        compare = new StringCompare();

        compare.Init();




        this.ItemTable = new Table();

        this.ItemTable.Compare = compare;

        this.ItemTable.Init();




        int count;

        count = this.ClassArray.Count;


        int i;

        i = 0;



        while (i < count)
        {
            Class varClass;

            varClass = (Class)this.ClassArray.Get(i);



            string a;

            a = varClass.Name;
            


            TableEntry entry;

            entry = this.GetItemEntry(a);



            this.ItemTable.Add(entry);



            i = i + 1;
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