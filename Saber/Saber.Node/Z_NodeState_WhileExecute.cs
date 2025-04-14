namespace Saber.Node;

public class WhileExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteWhileExecute(range);
        return true;
    }
}