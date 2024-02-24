namespace Class.Node;

public class InfExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteInfExecute(this.Arg);
        return true;
    }
}