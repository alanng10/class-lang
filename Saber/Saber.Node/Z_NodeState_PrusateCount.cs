namespace Saber.Node;

public class PrusateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecutePrusateCount(range);
        return true;
    }
}