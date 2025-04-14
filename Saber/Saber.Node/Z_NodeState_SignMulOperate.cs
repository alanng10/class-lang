namespace Saber.Node;

public class SignMulOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteSignMulOperate(range);
        return true;
    }
}