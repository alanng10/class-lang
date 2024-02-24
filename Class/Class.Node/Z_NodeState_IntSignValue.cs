namespace Class.Node;

public class IntSignValueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteIntSignValue(this.Arg);
        return true;
    }
}