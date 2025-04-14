namespace Saber.Node;

public class NewOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteNewOperate(range);
        return true;
    }
}