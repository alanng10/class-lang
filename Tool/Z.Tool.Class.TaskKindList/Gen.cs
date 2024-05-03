namespace Z.Tool.Class.TaskKindList;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Class.Console";


        this.ClassName = "TaskKindList";


        this.BaseClassName = "Any";


        this.ItemClassName = "TaskKind";


        this.ArrayClassName = "Array";




        this.Export = true;





        this.ItemListFileName = "ToolData/ItemListTaskKind.txt";



        this.AddMethodFileName = "ToolData/AddMethodTaskKind.txt";



        this.OutputFilePath = "../../Class/Class.Console/TaskKindList.cs";





        return true;
    }
}