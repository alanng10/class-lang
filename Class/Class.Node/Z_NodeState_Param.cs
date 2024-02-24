namespace Class.Node;

public class ParamNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteParam(this.Arg);
        return true;
    }
}