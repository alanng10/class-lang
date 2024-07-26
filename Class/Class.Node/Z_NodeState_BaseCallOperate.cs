namespace Class.Node;

public class BaseCallOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBaseCallOperate(range);
        return true;
    }
}