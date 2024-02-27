namespace Z.Tool.AccessListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Class.Infra";


        this.ClassName = "AccessList";


        this.BaseClassName = "Any";


        this.ItemClassName = "Access";


        this.ArrayClassName = "Array";




        this.Export = true;





        this.ItemListFileName = "ItemListAccess.txt";



        this.AddMethodFileName = "AddMethodAccess.txt";



        this.OutputFilePath = "../../Class/Class.Infra/AccessList.cs";





        return true;
    }
}