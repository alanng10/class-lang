namespace Class.Refer;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    public virtual Data Data { get; set; }
    public virtual int Index { get; set; }
    public virtual Refer Refer { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    public virtual int StringIndex { get; set; }
    public virtual int StringDataIndex { get; set; }
    public virtual int ArrayIndex { get; set; }
    public virtual int FieldIndex { get; set; }

    public virtual bool Execute()
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
        Data data;
        data = this.Data;
        int dataCount;
        dataCount = (int)data.Count;
        int count;
        count = sizeof(long);
        if (!((index < dataCount) & !(dataCount < (index + count))))
        {
            return -1;
        }

        long a;
        a = this.InfraInfra.DataIntGet(data, index);
        index = index + count;
        this.Index = index;
        return a;
    }

    public virtual int ExecuteByte()
    {
        int index;
        index = this.Index;
        Data data;
        data = this.Data;
        if (!(index < data.Count))
        {
            return -1;
        }

        int a;
        a = data.Get(index);
        index = index + 1;
        this.Index = index;
        return a;
    }
}