namespace Saber.Node;

public class ValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteValue(range);
        return true;
    }
}