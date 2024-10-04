namespace Saber.Node;

public class BitLiteOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitLiteOperate(range);
        return true;
    }
}