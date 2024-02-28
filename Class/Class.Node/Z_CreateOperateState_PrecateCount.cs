namespace Class.Node;

public class PrecateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        PrecateCount node;
        node = (PrecateCount)this.Node;

        return true;
    }
}