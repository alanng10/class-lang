namespace Saber.Node;

public class IntSignValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteIntSignValue(range);
        return true;
    }
}