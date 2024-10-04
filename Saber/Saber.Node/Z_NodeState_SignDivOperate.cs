namespace Saber.Node;

public class SignDivOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteSignDivOperate(range);
        return true;
    }
}