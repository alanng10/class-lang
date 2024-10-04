namespace Saber.Node;

public class ClassNameNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteClassName(range);
        return true;
    }
}