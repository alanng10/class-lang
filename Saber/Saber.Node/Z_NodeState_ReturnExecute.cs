namespace Saber.Node;

public class ReturnExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteReturnExecute(range);
        return true;
    }
}