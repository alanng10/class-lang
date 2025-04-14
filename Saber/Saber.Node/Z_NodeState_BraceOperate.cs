namespace Saber.Node;

public class BraceOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteBraceOperate(range);
        return true;
    }
}