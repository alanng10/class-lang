namespace Class.Node;

public class AreExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteAreExecute(this.Arg);
        return true;
    }
}