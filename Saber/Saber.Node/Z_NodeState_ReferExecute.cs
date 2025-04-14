namespace Saber.Node;

public class ReferExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteReferExecute(range);
        return true;
    }
}