namespace Saber.Node;

public class BraceOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBraceOperate(range);
        return true;
    }
}