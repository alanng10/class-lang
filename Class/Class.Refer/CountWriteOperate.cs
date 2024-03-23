namespace Class.Refer;

public class CountWriteOperate : WriteOperate
{
    public override bool Execute(int value)
    {
        int index;
        index = this.Write.Index;
        index = index + 1;
        this.Write.Index = index;
        return true;
    }
}