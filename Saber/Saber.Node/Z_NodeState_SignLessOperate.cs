namespace Saber.Node;

public class SignLessOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteSignLessOperate(range);
        return true;
    }
}