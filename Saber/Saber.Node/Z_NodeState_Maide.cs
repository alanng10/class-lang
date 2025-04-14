namespace Saber.Node;

public class MaideNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteMaide(range);
        return true;
    }
}