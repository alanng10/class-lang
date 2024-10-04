namespace Class.Node;

public class GetOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteGetOperate(range);
        return true;
    }
}