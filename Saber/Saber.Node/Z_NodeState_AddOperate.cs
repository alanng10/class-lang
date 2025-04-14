namespace Saber.Node;

public class AddOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteAddOperate(range);
        return true;
    }
}