namespace Saber.Node;

public class SignDivOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteSignDivOperate(range);
        return true;
    }
}