namespace Saber.Node;

public class OperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteOperate(range);
        return true;
    }
}