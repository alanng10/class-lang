namespace Saber.Node;

public class MulOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteMulOperate(range);
        return true;
    }
}