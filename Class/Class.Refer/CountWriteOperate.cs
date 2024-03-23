namespace Class.Refer;

public class CountWriteOperate : WriteOperate
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
        index = index + 1;
        this.Write.Index = index;
        return true;
    }

    public override bool ExecuteInt(long value)
    {
        int index;
        index = this.Write.Index;
        index = index + this.InfraInfra.IntByteCount;
        this.Write.Index = index;
        return true;
    }
}