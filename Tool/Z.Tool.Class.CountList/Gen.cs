namespace Z.Tool.CountListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Class.Infra";


        this.ClassName = "CountList";


        this.BaseClassName = "Any";


        this.ItemClassName = "Count";


        this.ArrayClassName = "Array";




        this.Export = true;





        this.ItemListFileName = "ItemListCount.txt";



        this.AddMethodFileName = "AddMethodCount.txt";



        this.OutputFilePath = "../../Class/Class.Infra/CountList.cs";





        return true;
    }
}