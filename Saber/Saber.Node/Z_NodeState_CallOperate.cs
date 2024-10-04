namespace Saber.Node;

public class CallOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteCallOperate(range);
        return true;
    }
}