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
    protected virtual InfraInfra InfraInfra { get; set; }

    protected virtual long ExecuteInt()
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

    protected virtual int ExecuteByte()
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