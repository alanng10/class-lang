namespace Saber.Console;

public class StringTravel : Travel
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
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

    protected virtual Iter CreateTableIter()
    {
        Iter a;
        a = new TableIter();
        a.Init();
        return a;
    }

    public virtual ClassModule Module { get; set; }
    public virtual Array Result { get; set; }
    public virtual StringArg Arg { get; set; }
    public virtual StringCountOperate CountOperate { get; set; }
    public virtual StringSetOperate SetOperate { get; set; }
    public virtual StringOperate Operate { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual Iter TableIter { get; set; }

    public virtual bool Execute()
    {
        this.Result = this.ListInfra.ArrayCreate(this.Module.Class.Count);

        this.Arg = new StringArg();
        this.Arg.Init();

        this.Arg.ClassCountData = new Data();
        this.Arg.ClassCountData.Count = this.Module.Class.Count * sizeof(long);
        this.Arg.ClassCountData.Init();

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Arg.Array = this.ListInfra.ArrayCreate(this.Arg.Index);

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.ExecuteResultSet();

        this.Operate = null;
        this.Arg = null;
        return true;
    }

    protected virtual bool ExecuteResultSet()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Data data;
        data = this.Arg.ClassCountData;

        Array stringArray;
        stringArray = this.Arg.Array;

        long totalString;
        totalString = 0;

        long count;
        count = this.Module.Class.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long ka;
            ka = i * sizeof(long);

            long stringCount;
            stringCount = infraInfra.DataIntGet(data, ka);

            Array array;
            array = listInfra.ArrayCreate(stringCount);

            listInfra.ArrayCopy(array, 0, stringArray, totalString, stringCount);

            this.Result.SetAt(i, array);

            totalString = totalString + stringCount;

            i = i + 1;
        }

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
        this.Operate.ExecuteString(stringValue.Value);
        return true;
    }
}