namespace Class.Node;

public class CountNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteCount(this.Arg);
        return true;
    }
}