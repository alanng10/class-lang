namespace Saber.Node;

public class OperateExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteOperateExecute(range);
        return true;
    }
}