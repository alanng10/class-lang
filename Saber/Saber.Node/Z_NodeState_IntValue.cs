namespace Saber.Node;

public class IntValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteIntValue(range);
        return true;
    }
}