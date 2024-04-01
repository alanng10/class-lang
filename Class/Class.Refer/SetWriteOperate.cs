namespace Class.Refer;

public class SetWriteOperate : WriteOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    public virtual Write Write { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }

    public override bool ExecuteByte(int value)
    {
        int index;
        index = this.Write.Index;
        Data data;
        data = this.Write.Data;
        data.Set(index, value);
        index = index + 1;
        this.Write.Index = index;
        return true;
    }

    public override bool ExecuteInt(long value)
    {
        int index;
        index = this.Write.Index;
        Data data;
        data = this.Write.Data;
        int count;
        count = sizeof(long);
        this.InfraInfra.DataIntSet(data, index, value);
        index = index + count;
        this.Write.Index = index;
        return true;
    }
}