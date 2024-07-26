namespace Class.Node;

public class PrecateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        PrecateCount node;
        node = (PrecateCount)this.Node;
        return true;
    }
}