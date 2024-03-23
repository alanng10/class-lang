namespace Class.Refer;

public class SetWriteOperate : WriteOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.DataWrite = new DataWrite();
        this.DataWrite.Init();
        return true;
    }

    public virtual Write Write { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual DataWrite DataWrite { get; set; }

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
        count = this.InfraInfra.IntByteCount;
        ulong o;
        o = (ulong)value;
        this.DataWrite.Data = data;
        this.DataWrite.ExecuteULong(index, o);
        this.DataWrite.Data = null;
        index = index + count;
        this.Write.Index = index;
        return true;
    }
}