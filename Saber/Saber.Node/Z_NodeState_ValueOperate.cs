namespace Saber.Node;

public class ValueOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteValueOperate(range);
        return true;
    }
}