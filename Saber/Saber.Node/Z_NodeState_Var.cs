namespace Saber.Node;

public class VarNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteVar(range);
        return true;
    }
}