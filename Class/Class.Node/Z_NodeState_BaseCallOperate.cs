namespace Class.Node;

public class BaseCallOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBaseCallOperate(this.Arg);
        return true;
    }
}