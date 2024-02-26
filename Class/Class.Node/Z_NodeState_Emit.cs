namespace Class.Node;

public class EmitNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteEmit(this.Arg);
        return true;
    }
}