namespace Saber.Node;

public class ThisOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteThisOperate(range);
        return true;
    }
}