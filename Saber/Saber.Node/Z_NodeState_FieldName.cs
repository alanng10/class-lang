namespace Saber.Node;

public class FieldNameNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteFieldName(range);
        return true;
    }
}