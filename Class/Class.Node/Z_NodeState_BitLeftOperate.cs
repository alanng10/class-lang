namespace Class.Node;

public class BitLeftOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitLeftOperate(range);
        return true;
    }
}