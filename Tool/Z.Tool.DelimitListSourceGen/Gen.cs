namespace Z.Tool.DelimitListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Class.Infra";


        this.ClassName = "DelimitList";


        this.BaseClassName = "Any";


        this.ItemClassName = "Delimit";


        this.ArrayClassName = "Array";




        this.Export = true;





        this.ItemListFileName = "ItemListDelimit.txt";



        this.AddMethodFileName = "AddMethodDelimit.txt";



        this.OutputFilePath = "../../Class/Class.Infra/DelimitList.cs";





        return true;
    }







    protected override TableEntry GetItemEntry(string line)
    {
        string[] ua;


        ua = line.Split(' ');




        string index;

        index = ua[0];





        string text;

        text = ua[1];






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