namespace Class.Node;

public class ProbateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        ProbateCount node;
        node = (ProbateCount)this.Node;
        return true;
    }
}