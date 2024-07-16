namespace Class.Node;

public class ReferExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteReferExecute(this.Arg);
        return true;
    }
}