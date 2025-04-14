namespace Saber.Node;

public class VarNameNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteVarName(range);
        return true;
    }
}