namespace Saber.Node;

public class DivOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteDivOperate(range);
        return true;
    }
}