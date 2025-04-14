namespace Saber.Node;

public class IntHexSignValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteIntHexSignValue(range);
        return true;
    }
}