namespace Class.Infra;

public class AddWriteOperate : WriteOperate
{
    public virtual StringValueWrite Write { get; set; }

    public override bool ExecuteChar(char oc)
    {
        int index;
        index = this.Write.Index;

        this.Write.Array[index] = oc;
        
        index = index + 1;

        this.Write.Index = index;
        return true;
    }
}