namespace Saber.Node;

public class OrnOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteOrnOperate(range);
        return true;
    }
}