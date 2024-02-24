namespace Class.Node;

public class PartNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePart(this.Arg);
        return true;
    }
}