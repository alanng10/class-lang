namespace Saber.Console;

public class BinaryState : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.StringComp = StringComp.This;

        this.CountOperate = this.CreateCountOperate();
        this.SetOperate = this.CreateSetOperate();
        this.Travel = this.CreateTravel();
        this.ClassIter = this.CreateClassIter();
        this.TableIter = this.CreateTableIter();
        return true;
    }

    protected virtual BinaryStateCountOperate CreateCountOperate()
    {
        BinaryStateCountOperate a;
        a = new BinaryStateCountOperate();
        a.State = this;
        a.Init();
        return a;
    }

    protected virtual BinaryStateSetOperate CreateSetOperate()
    {
        BinaryStateSetOperate a;
        a = new BinaryStateSetOperate();
        a.State = this;
        a.Init();
        return a;
    }

    protected virtual BinaryStateTravel CreateTravel()
    {
        BinaryStateTravel a;
        a = new BinaryStateTravel();
        a.State = this;
        a.Init();
        return a;
    }

    protected virtual TableIter CreateClassIter()
    {
        return this.CreateTableIter();
    }

    protected virtual TableIter CreateTableIter()
    {
        TableIter a;
        a = new TableIter();
        a.Init();
        return a;
    }

    public virtual ClassModule Module { get; set; }
    public virtual Table IndexTable { get; set; }
    public virtual Data Result { get; set; }
    public virtual BinaryStateArg Arg { get; set; }
    public virtual BinaryStateOperate Operate { get; set; }
    public virtual BinaryStateCountOperate CountOperate { get; set; }
    public virtual BinaryStateSetOperate SetOperate { get; set; }
    public virtual long StateCount { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual BinaryStateTravel Travel { get; set; }
    protected virtual TableIter ClassIter { get; set; }
    protected virtual TableIter TableIter { get; set; }

    public virtual bool Execute()
    {
        this.StateCount = this.StateCountGet();

        this.Arg = new BinaryStateArg();
        this.Arg.Init();

        this.Arg.OperateCountData = new Data();
        this.Arg.OperateCountData.Count = this.StateCount * sizeof(long);
        this.Arg.OperateCountData.Init();

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        long count;
        count = this.Arg.Index;
        this.Arg.Data = new Data();
        this.Arg.Data.Count = count;
        this.Arg.Data.Init();

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Result = this.Arg.Data;

        this.Operate = null;
        this.Arg = null;
        this.StateCount = 0;
        return true;
    }

    public virtual long StateCountGet()
    {
        long count;
        count = 0;

        Iter iter;
        iter = this.ClassIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            count = count + varClass.Field.Count * 2;

            count = count + varClass.Maide.Count;
        }

        iter.Clear();

        return count;
    }

    public virtual bool ResetStage()
    {
        this.Arg.Index = 0;
        this.Arg.StringIndex = 0;
        this.Arg.StateIndex = 0;
        this.Arg.OperateIndex = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        this.ExecuteCount(this.StateCount);

        Iter iter;
        iter = this.ClassIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            this.ExecuteClass(varClass);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteClass(ClassClass varClass)
    {
        Iter iter;
        iter = this.TableIter;

        varClass.Field.IterSet(iter);

        while (iter.Next())
        {
            Field varField;
            varField = iter.Value as Field;

            this.ExecuteField(varField);
        }

        varClass.Maide.IterSet(iter);

        while (iter.Next())
        {
            Maide varMaide;
            varMaide = iter.Value as Maide;

            this.ExecuteMaide(varMaide);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteField(Field varField)
    {
        this.ExecuteFieldGet(varField);

        this.ExecuteFieldSet(varField);
        return true;
    }

    public virtual bool ExecuteFieldGet(Field varField)
    {
        NodeField nodeField;
        nodeField = varField.Any as NodeField;

        this.ExecuteCompState(nodeField.Get, varField.Get.Count);
        return true;
    }

    public virtual bool ExecuteFieldSet(Field varField)
    {
        NodeField nodeField;
        nodeField = varField.Any as NodeField;

        this.ExecuteCompState(nodeField.Set, varField.Set.Count);
        return true;
    }

    public virtual bool ExecuteMaide(Maide varMaide)
    {
        this.ExecuteMaideCall(varMaide);
        return true;
    }

    public virtual bool ExecuteMaideCall(Maide varMaide)
    {
        NodeMaide nodeMaide;
        nodeMaide = varMaide.Any as NodeMaide;

        this.ExecuteCompState(nodeMaide.Call, varMaide.Call.Count);
        return true;
    }

    public virtual bool ExecuteCompState(State state, long varVar)
    {
        this.ExecuteCount(varVar);

        this.Operate.ExecuteTravelStart();

        this.Travel.ExecuteState(state);

        this.Operate.ExecuteTravelEnd();
        return true;
    }

    public virtual bool ExecuteOperate(BinaryOperate operate)
    {
        this.ExecuteByte(operate.Kind);

        this.ExecuteOperateArg(operate.ArgA);
        this.ExecuteOperateArg(operate.ArgB);

        this.Operate.ExecuteOperate();
        return true;
    }

    public virtual bool ExecuteOperateArg(BinaryOperateArg arg)
    {
        if (arg.Kind == 0)
        {
            return true;
        }

        if (arg.Kind == 1)
        {
            this.ExecuteBool(arg.Bool);
        }

        if (arg.Kind == 2)
        {
            this.ExecuteInt(arg.Int);
        }

        if (arg.Kind == 3)
        {
            this.ExecuteStringArg();
        }

        return true;
    }

    public virtual bool ExecuteStringArg()
    {
        return true;
    }

    public virtual bool ExecuteString(String value)
    {
        long count;
        count = this.StringComp.Count(value);

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            long ka;
            ka = this.StringComp.Char(value, i);

            this.ExecuteMid(ka);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteBool(bool value)
    {
        long k;
        k = 0;

        if (value)
        {
            k = 1;
        }

        this.ExecuteByte(k);
        return true;
    }

    public virtual bool ExecuteCount(long value)
    {
        return this.ExecuteInt(value);
    }

    public virtual bool ExecuteMid(long value)
    {
        return this.ExecuteIntCount(value, sizeof(int));
    }

    public virtual bool ExecuteInt(long value)
    {
        return this.ExecuteIntCount(value, sizeof(long));
    }

    public virtual bool ExecuteIntCount(long value, long count)
    {
        long k;
        k = value;
        k = k & (this.InfraInfra.IntCapValue - 1);

        long i;
        i = 0;
        while (i < count)
        {
            int shift;
            shift = (int)(i * 8);

            long ka;
            ka = (k >> shift) & 0xff;

            this.ExecuteByte(ka);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteByte(long value)
    {
        this.Operate.ExecuteByte(value);
        return true;
    }

    public virtual long ClassIndex(ClassClass varClass)
    {
        InfraValue k;
        k = this.IndexTable.Get(varClass) as InfraValue;

        long a;
        a = k.Int;

        return a;
    }
}