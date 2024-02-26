namespace Class.Node;

public class PrecateEmitNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrecateEmit(this.Arg);
        return true;
    }
}