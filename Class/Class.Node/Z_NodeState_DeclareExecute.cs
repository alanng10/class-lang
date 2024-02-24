namespace Class.Node;

public class DeclareExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteDeclareExecute(this.Arg);
        return true;
    }
}