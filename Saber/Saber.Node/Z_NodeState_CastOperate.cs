namespace Saber.Node;

public class CastOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteCastOperate(range);
        return true;
    }
}