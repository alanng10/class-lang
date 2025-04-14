namespace Saber.Node;

public class BaseOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBaseOperate(range);
        return true;
    }
}