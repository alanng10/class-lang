namespace Class.Infra;

public class CountWriteOperate : WriteOperate
{
    public virtual StringValueWrite Write { get; set; }

    public override bool ExecuteChar(char oc)
    {
        int index;
        index = this.Write.Index;
        index = index + 1;
        this.Write.Index = index;
        return true;
    }
}