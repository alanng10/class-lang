namespace Class.Node;





public class WhileExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteWhileExecute(this.Arg);



        return true;
    }
}