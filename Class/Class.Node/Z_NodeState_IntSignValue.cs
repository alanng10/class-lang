namespace Class.Node;

public class IntSignValueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteIntSignValue(range);
        return true;
    }
}