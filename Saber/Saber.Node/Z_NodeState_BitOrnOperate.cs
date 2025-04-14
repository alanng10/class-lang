namespace Saber.Node;

public class BitOrnOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBitOrnOperate(range);
        return true;
    }
}