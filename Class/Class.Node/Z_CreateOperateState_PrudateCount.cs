namespace Class.Node;

public class PrudateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        PrudateCount node;
        node = (PrudateCount)this.Node;
        return true;
    }
}