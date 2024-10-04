namespace Saber.Node;

public class LessOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteLessOperate(range);
        return true;
    }
}