namespace Saber.Node;

public class ParamNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteParam(range);
        return true;
    }
}