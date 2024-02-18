namespace Z.Tool.NodeListSourceGen;






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



        this.OutputFilePath = "../../Class.Node/NodeKindList.cs";





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







    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        string newState;

        newState = index + "NewState";



        string nodeState;

        nodeState = index + "NodeState";



        string createOperateState;

        createOperateState = index + "CreateOperateState";




        sb
            .Append("AddItem")
            .Append("(")
            .Append("\"").Append(index).Append("\"").Append(",").Append(" ")
            .Append("new").Append(" ").Append(index).Append("(").Append(")").Append(",").Append(" ")
            .Append("new").Append(" ").Append(newState).Append("(").Append(")").Append(",").Append(" ")
            .Append("new").Append(" ").Append(nodeState).Append("(").Append(")").Append(",").Append(" ")
            .Append("new").Append(" ").Append(createOperateState).Append("(").Append(")")
            .Append(")")
            ;





        return true;
    }
}