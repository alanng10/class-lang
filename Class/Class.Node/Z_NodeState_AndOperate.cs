namespace Class.Node;

public class AndOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteAndOperate(this.Arg);
        return true;
    }
}