namespace Saber.Node;

public class AndOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteAndOperate(range);
        return true;
    }
}