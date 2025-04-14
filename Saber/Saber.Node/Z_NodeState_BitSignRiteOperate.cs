namespace Saber.Node;

public class BitSignRiteOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBitSignRiteOperate(range);
        return true;
    }
}