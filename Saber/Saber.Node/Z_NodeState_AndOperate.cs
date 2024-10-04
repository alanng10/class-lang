namespace Saber.Node;

public class AndOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteAndOperate(range);
        return true;
    }
}