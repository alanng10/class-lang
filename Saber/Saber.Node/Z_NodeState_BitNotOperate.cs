namespace Saber.Node;

public class BitNotOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBitNotOperate(range);
        return true;
    }
}