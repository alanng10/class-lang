namespace Saber.Node;

public class NullOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteNullOperate(range);
        return true;
    }
}