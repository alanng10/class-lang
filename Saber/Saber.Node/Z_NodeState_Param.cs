namespace Saber.Node;

public class ParamNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteParam(range);
        return true;
    }
}