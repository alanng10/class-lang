namespace Class.Node;

public class ProbateEmitCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        ProbateEmit node;
        node = (ProbateEmit)this.Node;

        return true;
    }
}