namespace Saber.Node;

public class FieldNameNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteFieldName(range);
        return true;
    }
}