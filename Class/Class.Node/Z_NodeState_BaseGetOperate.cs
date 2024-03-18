namespace Class.Node;

public class BaseGetOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBaseGetOperate(this.Arg);
        return true;
    }
}