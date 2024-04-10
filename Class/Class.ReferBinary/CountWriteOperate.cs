namespace Class.Refer;

public class CountWriteOperate : WriteOperate
{
    public virtual Write Write { get; set; }

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
        index = index + sizeof(long);
        this.Write.Index = index;
        return true;
    }
}