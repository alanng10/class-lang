namespace Class.Node;

public class PrivateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        PrivateCount node;
        node = (PrivateCount)this.Node;
        return true;
    }
}