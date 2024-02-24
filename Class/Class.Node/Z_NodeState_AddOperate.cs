namespace Class.Node;

public class AddOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteAddOperate(this.Arg);
        return true;
    }
}