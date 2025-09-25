namespace Saber.Console;

public class StringTravel : Travel
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;

        this.CountOperate = this.CreateCountOperate();
        this.SetOperate = this.CreateSetOperate();
        this.TableIter = this.CreateTableIter();
        return true;
    }

    protected virtual StringCountOperate CreateCountOperate()
    {
        StringCountOperate a;
        a = new StringCountOperate();
        a.Travel = this;
        a.Init();
        return a;
    }

    protected virtual StringSetOperate CreateSetOperate()
    {
        StringSetOperate a;
        a = new StringSetOperate();
        a.Travel = this;
        a.Init();
        return a;
    }

    protected virtual TableIter CreateTableIter()
    {
        TableIter a;
        a = new TableIter();
        a.Init();
        return a;
    }

    public virtual ClassModule Module { get; set; }
    public virtual Array Result { get; set; }
    public virtual StringArg Arg { get; set; }
    public virtual StringOperate Operate { get; set; }
    public virtual StringCountOperate CountOperate { get; set; }
    public virtual StringSetOperate SetOperate { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TableIter TableIter { get; set; }

    public virtual bool Execute()
    {
        this.Arg = new StringArg();
        this.Arg.Init();

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Arg.Array = this.ListInfra.ArrayCreate(this.Arg.Index);

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Result = this.Arg.Array;

        this.Operate = null;
        this.Arg = null;
        return true;
    }

    public virtual bool ResetStage()
    {
        this.Arg.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        Iter iter;
        iter = this.TableIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            NodeClass nodeClass;
            nodeClass = varClass.Any as NodeClass;

            this.ExecuteClass(nodeClass);
        }

        iter.Clear();
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        this.Operate.ExecuteString(stringValue.Value);
        return true;
    }
}