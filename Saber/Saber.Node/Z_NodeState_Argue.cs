namespace Saber.Node;

public class ArgueNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteArgue(range);
        return true;
    }
}