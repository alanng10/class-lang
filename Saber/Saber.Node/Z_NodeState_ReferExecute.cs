namespace Saber.Node;

public class ReferExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteReferExecute(range);
        return true;
    }
}