namespace Z.Tool.TaskKindListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Class";


        this.ClassName = "TaskKindList";


        this.BaseClassName = "Any";


        this.ItemClassName = "TaskKind";


        this.ArrayClassName = "Array";




        this.Export = true;





        this.ItemListFileName = "ItemListTaskKind.txt";



        this.AddMethodFileName = "AddMethodTaskKind.txt";



        this.OutputFilePath = "../../../../Class/TaskKindList.cs";





        return true;
    }
}