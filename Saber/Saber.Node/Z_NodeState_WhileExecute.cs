namespace Saber.Node;

public class WhileExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteWhileExecute(range);
        return true;
    }
}