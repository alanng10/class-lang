namespace Class.Node;

public class PrusateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        PrusateCount node;
        node = (PrusateCount)this.Node;
        return true;
    }
}