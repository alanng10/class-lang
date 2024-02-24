namespace Class.Node;

public class BracketOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBracketOperate(this.Arg);
        return true;
    }
}