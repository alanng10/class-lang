namespace Saber.Node;

public class SameOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteSameOperate(range);
        return true;
    }
}