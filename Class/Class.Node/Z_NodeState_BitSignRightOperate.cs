namespace Class.Node;

public class BitSignRightOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitSignRightOperate(range);
        return true;
    }
}