namespace Saber.Node;

public class SignLessOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteSignLessOperate(range);
        return true;
    }
}