namespace Saber.Node;

public class BitRiteOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitRiteOperate(range);
        return true;
    }
}