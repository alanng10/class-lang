namespace Saber.Node;

public class OperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteOperate(range);
        return true;
    }
}