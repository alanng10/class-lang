namespace Class.Node;

public class SignLessOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteSignLessOperate(this.Arg);
        return true;
    }
}