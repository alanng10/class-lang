namespace Saber.Node;

public class OperateExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteOperateExecute(range);
        return true;
    }
}