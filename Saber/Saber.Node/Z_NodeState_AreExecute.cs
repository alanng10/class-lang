namespace Saber.Node;

public class AreExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteAreExecute(range);
        return true;
    }
}