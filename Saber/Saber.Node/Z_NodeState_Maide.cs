namespace Saber.Node;

public class MaideNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteMaide(range);
        return true;
    }
}