namespace Class.Node;

public class ReturnExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteReturnExecute(this.Arg);
        return true;
    }
}