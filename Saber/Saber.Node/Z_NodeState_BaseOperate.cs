namespace Saber.Node;

public class BaseOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBaseOperate(range);
        return true;
    }
}