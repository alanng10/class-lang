namespace Saber.Node;

public class InfExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteInfExecute(range);
        return true;
    }
}