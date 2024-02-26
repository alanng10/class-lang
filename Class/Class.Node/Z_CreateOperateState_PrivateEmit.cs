namespace Class.Node;

public class PrivateEmitCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        PrivateEmit node;
        node = (PrivateEmit)this.Node;

        return true;
    }
}