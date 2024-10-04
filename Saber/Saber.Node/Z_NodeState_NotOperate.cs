namespace Saber.Node;

public class NotOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteNotOperate(range);
        return true;
    }
}