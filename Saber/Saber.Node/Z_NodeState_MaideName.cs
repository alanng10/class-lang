namespace Saber.Node;

public class MaideNameNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteMaideName(range);
        return true;
    }
}