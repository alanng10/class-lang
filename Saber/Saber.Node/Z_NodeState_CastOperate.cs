namespace Saber.Node;

public class CastOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteCastOperate(range);
        return true;
    }
}