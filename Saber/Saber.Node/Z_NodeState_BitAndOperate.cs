namespace Saber.Node;

public class BitAndOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitAndOperate(range);
        return true;
    }
}