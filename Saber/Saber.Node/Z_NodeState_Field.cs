namespace Saber.Node;

public class FieldNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteField(range);
        return true;
    }
}