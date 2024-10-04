namespace Saber.Node;

public class ShareOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteShareOperate(range);
        return true;
    }
}