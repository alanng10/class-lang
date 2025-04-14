namespace Saber.Node;

public class ThisOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteThisOperate(range);
        return true;
    }
}