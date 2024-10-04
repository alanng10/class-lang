namespace Saber.Node;

public class ClassNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteClass(range);
        return true;
    }
}