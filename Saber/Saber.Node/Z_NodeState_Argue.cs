namespace Saber.Node;

public class ArgueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteArgue(range);
        return true;
    }
}