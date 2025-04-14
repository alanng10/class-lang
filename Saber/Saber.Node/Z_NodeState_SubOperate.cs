namespace Saber.Node;

public class SubOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteSubOperate(range);
        return true;
    }
}