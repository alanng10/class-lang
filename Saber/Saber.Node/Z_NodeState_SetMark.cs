namespace Saber.Node;

public class SetMarkNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteSetMark(range);
        return true;
    }
}