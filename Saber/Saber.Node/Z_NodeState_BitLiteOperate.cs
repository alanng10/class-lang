namespace Saber.Node;

public class BitLiteOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBitLiteOperate(range);
        return true;
    }
}