namespace Class.Node;

public class SetMarkNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteSetMark(range);
        return true;
    }
}