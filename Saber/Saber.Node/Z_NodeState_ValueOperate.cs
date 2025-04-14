namespace Saber.Node;

public class ValueOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteValueOperate(range);
        return true;
    }
}