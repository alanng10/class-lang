namespace Class.Node;

public class StringValueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteStringValue(this.Arg);
        return true;
    }
}