namespace Class.Node;

public class BracketOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBracketOperate(range);
        return true;
    }
}