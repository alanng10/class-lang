namespace Saber.Node;

public class VarNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteVar(range);
        return true;
    }
}