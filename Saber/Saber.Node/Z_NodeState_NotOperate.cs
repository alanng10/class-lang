namespace Saber.Node;

public class NotOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteNotOperate(range);
        return true;
    }
}