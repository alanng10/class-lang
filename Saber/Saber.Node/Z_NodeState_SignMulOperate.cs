namespace Saber.Node;

public class SignMulOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteSignMulOperate(range);
        return true;
    }
}