namespace Class.Node;

public class PrivateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        PrivateCount node;
        node = (PrivateCount)this.Node;

        return true;
    }
}