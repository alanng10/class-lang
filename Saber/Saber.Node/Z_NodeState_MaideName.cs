namespace Saber.Node;

public class MaideNameNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteMaideName(range);
        return true;
    }
}