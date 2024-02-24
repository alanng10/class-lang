namespace Class.Node;

public class ExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteExecute(this.Arg);
        return true;
    }
}