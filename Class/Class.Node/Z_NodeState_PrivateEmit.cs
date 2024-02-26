namespace Class.Node;

public class PrivateEmitNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrivateEmit(this.Arg);
        return true;
    }
}