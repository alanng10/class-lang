namespace Saber.Node;

public class ValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteValue(range);
        return true;
    }
}