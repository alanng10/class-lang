namespace Z.Tool.Saber.TaskKindList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Saber.Console");
        this.ClassName = this.S("TaskKindList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("TaskKind");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ItemListFileName = this.S("ToolData/Class/ItemListTaskKind.txt");
        this.AddMethodFileName = this.S("ToolData/Class/AddMaideTaskKind.txt");
        this.OutputFilePath = this.S("../../Saber/Saber.Console/TaskKindList.cs");
        return true;
    }
}