namespace Saber.Node;

public class NullOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteNullOperate(range);
        return true;
    }
}