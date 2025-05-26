namespace Saber.Console;

public class StringTravel : Travel
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;

        this.CountOperate = new StringValueCountOperate();
        this.CountOperate.Travel = this;
        this.CountOperate.Init();

        this.SetOperate = new StringValueSetOperate();
        this.SetOperate.Travel = this;
        this.SetOperate.Init();

        this.TableIter = new TableIter();
        this.TableIter.Init();
        return true;
    }

    public virtual ClassModule Module { get; set; }
    public virtual long Index { get; set; }
    public virtual Array Array { get; set; }
    public virtual StringValueCountOperate CountOperate { get; set; }
    public virtual StringValueSetOperate SetOperate { get; set; }
    public virtual StringValueOperate Operate { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual Iter TableIter { get; set; }

    public virtual bool Execute()
    {
        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Array = this.ListInfra.ArrayCreate(this.Index);

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();
        return true;
    }

    public virtual bool ResetStage()
    {
        this.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        Iter iter;
        iter = this.TableIter;
        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass k;
            k = iter.Value as ClassClass;

            NodeClass nodeClass;
            nodeClass = k.Any as NodeClass;

            this.ExecuteClass(nodeClass);
        }

        iter.Clear();
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        this.Operate.Execute(stringValue.Value);
        return true;
    }
}