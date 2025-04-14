namespace Saber.Node;

public class StateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteState(range);
        return true;
    }
}