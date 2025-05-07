namespace Saber.Node;

public class ArgueItemNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteOperate(range);
        return true;
    }
}