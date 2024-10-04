namespace Saber.Node;

public class ExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteExecute(range);
        return true;
    }
}