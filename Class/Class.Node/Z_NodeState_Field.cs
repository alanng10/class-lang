namespace Class.Node;

public class FieldNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteField(this.Arg);
        return true;
    }
}