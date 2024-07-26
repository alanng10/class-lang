namespace Class.Node;

public class NewOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteNewOperate(range);
        return true;
    }
}