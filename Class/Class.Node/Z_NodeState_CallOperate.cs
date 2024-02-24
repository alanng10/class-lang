namespace Class.Node;

public class CallOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteCallOperate(this.Arg);
        return true;
    }
}