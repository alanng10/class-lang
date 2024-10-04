namespace Saber.Node;

public class IntHexSignValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteIntHexSignValue(range);
        return true;
    }
}