namespace Saber.Node;

public class CallOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteCallOperate(range);
        return true;
    }
}