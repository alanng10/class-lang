namespace Saber.Node;

public class MulOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteMulOperate(range);
        return true;
    }
}