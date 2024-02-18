namespace Class.Node;





public class AssignExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteAssignExecute(this.Arg);



        return true;
    }
}