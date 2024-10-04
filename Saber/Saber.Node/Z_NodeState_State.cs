namespace Saber.Node;

public class StateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteState(range);
        return true;
    }
}