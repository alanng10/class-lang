namespace Saber.Node;

public class SubOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteSubOperate(range);
        return true;
    }
}