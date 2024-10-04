namespace Saber.Node;

public class PartNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecutePart(range);
        return true;
    }
}