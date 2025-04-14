namespace Saber.Node;

public class ExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteExecute(range);
        return true;
    }
}