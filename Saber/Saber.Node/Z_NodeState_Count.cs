namespace Saber.Node;

public class CountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteCount(range);
        return true;
    }
}