namespace Class.Node;

public class NewOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteNewOperate(this.Arg);
        return true;
    }
}