namespace Class.Refer;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.CountOperate = new CountReadOperate();
        this.CountOperate.Read = this;
        this.CountOperate.Init();
        return true;
    }

    public virtual Data Data { get; set; }
    public virtual int Index { get; set; }
    public virtual Refer Refer { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual Range Range { get; set; }
    public virtual int StringIndex { get; set; }
    public virtual int StringDataIndex { get; set; }
    public virtual Data StringData { get; set; }
    public virtual Array StringArray { get; set; }
    public virtual int ArrayIndex { get; set; }
    public virtual Array ArrayArray { get; set; }
    public virtual int FieldIndex { get; set; }

    public virtual bool Execute()
    {
        return true;
    }

    public virtual bool ExecuteStage()
    {
        return true;
    }

    protected virtual Array ExecuteFieldArray()
    {
        Array array;
        array = this.Operate.ExecuteArray();
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Field field;
            field = this.Operate.ExecuteField();
            if (!(field == null))
            {
                this.Operate.ExecuteArrayItemSet(array, i, field);
            }
            i = i + 1;
        }
        return array;
    }

    public virtual string ExecuteString()
    {
        return this.Operate.ExecuteString();
    }

    public virtual int ExecuteCount()
    {
        return (int)this.ExecuteInt();
    }

    public virtual int ExecuteIndex()
    {
        return (int)this.ExecuteInt();
    }

    public virtual long ExecuteInt()
    {
        int index;
        index = this.Index;
        int count;
        count = sizeof(long);
        if (!this.CheckCount(count))
        {
            return -1;
        }

        long a;
        a = this.InfraInfra.DataIntGet(this.Data, index);
        index = index + count;
        this.Index = index;
        return a;
    }

    public virtual int ExecuteByte()
    {
        int index;
        index = this.Index;
        if (!(this.CheckCount(1)))
        {
            return -1;
        }

        int a;
        a = this.Data.Get(index);
        index = index + 1;
        this.Index = index;
        return a;
    }

    public virtual bool CheckCount(int count)
    {
        Range range;
        range = this.Range;
        range.Index = this.Index;
        range.Count = count;
        int dataCount;
        dataCount = (int)this.Data.Count;
        return this.InfraInfra.CheckRange(dataCount, range);
    }
}