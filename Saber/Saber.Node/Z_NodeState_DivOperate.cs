namespace Saber.Node;

public class DivOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteDivOperate(range);
        return true;
    }
}