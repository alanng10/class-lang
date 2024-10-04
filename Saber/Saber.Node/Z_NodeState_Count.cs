namespace Saber.Node;

public class CountNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteCount(range);
        return true;
    }
}