namespace Saber.Node;

public class OrnOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteOrnOperate(range);
        return true;
    }
}