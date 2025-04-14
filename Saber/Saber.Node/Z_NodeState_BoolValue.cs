namespace Saber.Node;

public class BoolValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBoolValue(range);
        return true;
    }
}