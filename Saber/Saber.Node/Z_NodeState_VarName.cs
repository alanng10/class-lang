namespace Saber.Node;

public class VarNameNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteVarName(range);
        return true;
    }
}