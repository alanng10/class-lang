namespace Saber.Node;

public class StringValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteStringValue(range);
        return true;
    }
}