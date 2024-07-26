namespace Class.Node;

public class EqualOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteEqualOperate(range);
        return true;
    }
}