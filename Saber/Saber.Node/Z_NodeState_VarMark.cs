namespace Saber.Node;

public class VarMarkNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteVarMark(range);
        return true;
    }
}