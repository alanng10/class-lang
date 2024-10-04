namespace Saber.Node;

public class BitOrnOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitOrnOperate(range);
        return true;
    }
}