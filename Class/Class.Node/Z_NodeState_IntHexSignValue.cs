namespace Class.Node;

public class IntHexSignValueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteIntHexSignValue(this.Arg);
        return true;
    }
}