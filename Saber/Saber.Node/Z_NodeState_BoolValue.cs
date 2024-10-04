namespace Saber.Node;

public class BoolValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteBoolValue(range);
        return true;
    }
}