namespace Z.Tool.BinaryOperateKindListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Class.Binary";


        this.ClassName = "OperateKindList";


        this.BaseClassName = "Any";


        this.ItemClassName = "OperateKind";


        this.ArrayClassName = "Array";




        this.Export = true;





        this.ItemListFileName = "ItemListBinaryOperateKind.txt";



        this.AddMethodFileName = "AddMethodBinaryOperateKind.txt";



        this.OutputFilePath = "../../Class/Class.Binary/OperateKindList.cs";





        return true;
    }





    protected override TableEntry GetItemEntry(string line)
    {
        string[] ua;


        ua = line.Split(' ');




        string index;

        index = ua[0];



        string uua;

        uua = ua[1];
        
        
        
        string uub;

        uub = ua[2];



        bool ba;
        
        ba = this.ToolInfra.GetBool(uua);
        
        
        
        bool bb;
        
        bb = this.ToolInfra.GetBool(uub);
        



        Value value;

        value = new Value();

        value.Init();

        value.Arg = ba;

        value.AnyArg = bb;





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
            .Append(a.Arg.ToString().ToLower()).Append(",").Append(" ")
            .Append(a.AnyArg.ToString().ToLower())
            .Append(")");
            
        



        return true;
    }
}