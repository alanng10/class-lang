namespace Saber.Node;

public class CompNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteComp(range);
        return true;
    }
}