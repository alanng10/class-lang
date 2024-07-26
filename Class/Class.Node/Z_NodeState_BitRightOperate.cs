namespace Class.Node;

public class BitRightOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitRightOperate(range);
        return true;
    }
}