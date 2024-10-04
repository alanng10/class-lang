namespace Saber.Node;

public class AddOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteAddOperate(range);
        return true;
    }
}