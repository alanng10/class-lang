namespace Class.Refer;

public class SetWriteOperate : WriteOperate
{
    public virtual Write Write { get; set; }

    public override bool Execute(int value)
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
}