namespace Class.Node;

public class PrudateEmitNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrudateEmit(this.Arg);
        return true;
    }
}