namespace Saber.Node;

public class GetOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteGetOperate(range);
        return true;
    }
}