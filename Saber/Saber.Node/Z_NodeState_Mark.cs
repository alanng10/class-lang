namespace Saber.Node;

public class MarkNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteMark(range);
        return true;
    }
}