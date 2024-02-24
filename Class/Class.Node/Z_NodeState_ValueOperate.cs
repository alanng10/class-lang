namespace Class.Node;

public class ValueOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteValueOperate(this.Arg);
        return true;
    }
}