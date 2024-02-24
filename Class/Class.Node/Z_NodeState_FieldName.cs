namespace Class.Node;

public class FieldNameNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteFieldName(this.Arg);
        return true;
    }
}