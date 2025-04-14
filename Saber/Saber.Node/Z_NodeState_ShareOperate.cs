namespace Saber.Node;

public class ShareOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteShareOperate(range);
        return true;
    }
}