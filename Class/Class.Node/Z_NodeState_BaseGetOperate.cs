namespace Class.Node;

public class BaseGetOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBaseGetOperate(range);
        return true;
    }
}