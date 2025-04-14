namespace Saber.Node;

public class BitAndOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBitAndOperate(range);
        return true;
    }
}