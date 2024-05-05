namespace Class.Console;

public class ClassGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ClassInfra = ClassInfra.This;
        this.CountOperate = new CountClassGenOperate();
        this.CountOperate.Gen = this;
        this.CountOperate.Init();
        this.SetOperate = new SetClassGenOperate();
        this.SetOperate.Gen = this;
        this.SetOperate.Init();
        this.Traverse = new ClassGenTraverse();
        this.Traverse.Gen = this;
        this.Traverse.Init();
        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);
        return true;
    }

    public virtual ClassClass Class { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ModuleImportName { get; set; }
    public virtual ClassClass NullClass { get; set; }
    public virtual SystemClass System { get; set; }
    public virtual Data Data { get; set; }
    public virtual GenArg Arg { get; set; }
    public virtual ClassGenOperate Operate { get; set; }
    public virtual Maide ModuleInfoNameMaide { get; set; }
    public virtual Maide ModuleInfoVersionMaide { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountClassGenOperate CountOperate { get; set; }
    protected virtual SetClassGenOperate SetOperate { get; set; }
    protected virtual ClassGenTraverse Traverse { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }

    public virtual bool Execute()
    {
        this.Arg = new GenArg();
        this.Arg.Init();

        this.Operate = this.CountOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        long nn;
        nn = this.Arg.Index;
        nn = nn * sizeof(char);
        Data data;
        data = new Data();
        data.Count = nn;
        data.Init();
        this.Arg.Data = data;

        this.Operate = this.SetOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        this.Data = this.Arg.Data;
        this.Arg = null;
        return true;
    }

    protected virtual bool ResetStageIndex()
    {
        this.Arg.Index = 0;
        return true;
    }

    protected virtual bool ExecuteStage()
    {
        NodeClass nodeClass;
        nodeClass = (NodeClass)this.Class.Any;

        this.Traverse.ExecuteClass(nodeClass);
        return true;
    }
}