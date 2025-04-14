namespace Saber.Node;

public class ReturnExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteReturnExecute(range);
        return true;
    }
}