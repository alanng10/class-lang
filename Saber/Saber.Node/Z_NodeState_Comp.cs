namespace Saber.Node;

public class CompNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteComp(range);
        return true;
    }
}