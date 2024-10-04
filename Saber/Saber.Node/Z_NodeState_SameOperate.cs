namespace Saber.Node;

public class SameOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteSameOperate(range);
        return true;
    }
}