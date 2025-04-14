namespace Saber.Node;

public class IntValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteIntValue(range);
        return true;
    }
}