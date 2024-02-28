namespace Class.Node;

public class ProbateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        ProbateCount node;
        node = (ProbateCount)this.Node;

        return true;
    }
}