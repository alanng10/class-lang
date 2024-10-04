namespace Saber.Node;

public class BitSignRiteOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBitSignRiteOperate(range);
        return true;
    }
}