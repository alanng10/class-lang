namespace Saber.Node;

public class LessOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteLessOperate(range);
        return true;
    }
}