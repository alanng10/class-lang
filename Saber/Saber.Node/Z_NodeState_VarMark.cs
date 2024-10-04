namespace Saber.Node;

public class VarMarkNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteVarMark(range);
        return true;
    }
}