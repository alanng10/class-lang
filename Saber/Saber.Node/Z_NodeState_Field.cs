namespace Saber.Node;

public class FieldNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteField(range);
        return true;
    }
}