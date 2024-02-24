namespace Class.Node;

public class PrivateAccessCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        PrivateAccess node;
        node = (PrivateAccess)this.Node;

        return true;
    }
}