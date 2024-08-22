namespace Class.Node;

public class PronateCountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecutePronateCount(range);
        return true;
    }
}