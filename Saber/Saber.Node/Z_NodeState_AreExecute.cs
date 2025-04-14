namespace Saber.Node;

public class AreExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteAreExecute(range);
        return true;
    }
}