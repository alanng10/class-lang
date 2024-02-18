namespace Z.Tool.RefKindListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Class.Library";


        this.ClassName = "RefKindList";


        this.BaseClassName = "Any";


        this.ItemClassName = "RefKind";


        this.ArrayClassName = "Array";




        this.Export = true;





        this.ItemListFileName = "ItemListRefKind.txt";



        this.AddMethodFileName = "AddMethodRefKind.txt";



        this.OutputFilePath = "../../../../Class.Library/RefKindList.cs";





        return true;
    }
}