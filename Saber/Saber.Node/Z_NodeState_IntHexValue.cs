namespace Saber.Node;

public class IntHexValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteIntHexValue(range);
        return true;
    }
}