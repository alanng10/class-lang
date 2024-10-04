namespace Saber.Node;

public class InfExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteInfExecute(range);
        return true;
    }
}