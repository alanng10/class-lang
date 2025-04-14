namespace Saber.Node;

public class BitRiteOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBitRiteOperate(range);
        return true;
    }
}