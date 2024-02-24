namespace Class.Node;

public class ShareOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteShareOperate(this.Arg);
        return true;
    }
}