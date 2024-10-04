namespace Saber.Node;

public class BitNotOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitNotOperate(range);
        return true;
    }
}