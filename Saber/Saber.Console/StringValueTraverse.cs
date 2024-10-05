namespace Saber.Console;

public class StringValueTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;

        this.CountOperate = new CountStringValueOperate();
        this.CountOperate.Traverse = this;
        this.CountOperate.Init();

        this.SetOperate = new SetStringValueOperate();
        this.SetOperate.Traverse = this;
        this.SetOperate.Init();

        return true;
    }

    public virtual NodeClass Class { get; set; }

    public virtual long Index { get; set; }

    public virtual Array Array { get; set; }

    public virtual CountStringValueOperate CountOperate { get; set; }
    public virtual SetStringValueOperate SetOperate { get; set; }
    public virtual StringValueOperate Operate { get; set; }
    protected virtual ListInfra ListInfra { get; set; }

    public virtual bool Execute()
    {
        this.Operate = this.CountOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        this.Array = this.ListInfra.ArrayCreate(this.Index);

        this.Operate = this.SetOperate;

        this.ResetStageIndex();
        this.ExecuteStage();
        return true;
    }

    public virtual bool ResetStageIndex()
    {
        this.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        this.ExecuteClass(this.Class);
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        this.Operate.Execute(stringValue.Value);
        return true;
    }
}