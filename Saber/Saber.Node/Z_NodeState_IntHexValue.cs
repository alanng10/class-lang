namespace Saber.Node;

public class IntHexValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteIntHexValue(range);
        return true;
    }
}